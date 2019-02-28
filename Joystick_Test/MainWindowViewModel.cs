using SharpDX.DirectInput;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;

namespace Joystick_Test
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region

        Thread joystickThread;
        ThreadStart joystickThreadStart;

        Joystick joystick;
        DirectInput directInput;

        // Find a Joystick Guid
        Guid joystickGuid;

        bool activeThread;

        #endregion

        #region Binding Fields

        private int _X;
        private int _Y;
        private int _Z;
        private int _RotationZ;
        private int _PointOfViewControllers0;
        private int _Button0;
        private int _Button1;
        private int _Button2;
        private int _Button3;
        private int _Button4;
        private int _Button5;
        private int _Button6;
        private int _Button7;
        private int _Button8;
        private int _Button9;
        private int _Button10;
        private int _Button11;

        public int X
        {
            get { return _X; }
            set { _X = value; OnPropertyChanged("X"); }
        }

        public int Y
        {
            get { return _Y; }
            set { _Y = value; OnPropertyChanged("Y"); }
        }

        public int Z
        {
            get { return _Z; }
            set { _Z = value; OnPropertyChanged("Z"); }
        }

        public int RotationZ
        {
            get { return _RotationZ; }
            set { _RotationZ = value; OnPropertyChanged("RotationZ"); }
        }

        public int PointOfViewControllers0
        {
            get { return _PointOfViewControllers0; }
            set { _PointOfViewControllers0 = value; OnPropertyChanged("PointOfViewControllers0"); }
        }

        public int Button0
        {
            get { return _Button0; }
            set { _Button0 = value; OnPropertyChanged("Button0"); }
        }

        public int Button1
        {
            get { return _Button1; }
            set { _Button1 = value; OnPropertyChanged("Button1"); }
        }

        public int Button2
        {
            get { return _Button2; }
            set { _Button2 = value; OnPropertyChanged("Button2"); }
        }

        public int Button3
        {
            get { return _Button3; }
            set { _Button3 = value; OnPropertyChanged("Button3"); }
        }

        public int Button4
        {
            get { return _Button4; }
            set { _Button4 = value; OnPropertyChanged("Button4"); }
        }

        public int Button5
        {
            get { return _Button5; }
            set { _Button5 = value; OnPropertyChanged("Button5"); }
        }

        public int Button6
        {
            get { return _Button6; }
            set { _Button6 = value; OnPropertyChanged("Button6"); }
        }

        public int Button7
        {
            get { return _Button7; }
            set { _Button7 = value; OnPropertyChanged("Button7"); }
        }

        public int Button8
        {
            get { return _Button8; }
            set { _Button8 = value; OnPropertyChanged("Button8"); }
        }

        public int Button9
        {
            get { return _Button9; }
            set { _Button9 = value; OnPropertyChanged("Button9"); }
        }

        public int Button10
        {
            get { return _Button10; }
            set { _Button10 = value; OnPropertyChanged("Button10"); }
        }

        public int Button11
        {
            get { return _Button11; }
            set { _Button11 = value; OnPropertyChanged("Button11"); }
        }


        #endregion

        public MainWindowViewModel()
        {
            directInput = new DirectInput();
            joystickGuid = Guid.Empty;
        }
        
        public void ThreadDispose()
        {
            activeThread = false;
            joystickThread.Join();
        }

        ICommand _GetJoystickData_ButtonClickCommand;
        public ICommand GetJoystickData_ButtonClickCommand
        {
            get
            {
                _GetJoystickData_ButtonClickCommand = new DelegateCommand(obj =>
                {
                    joystickThreadStart = new ThreadStart(GetJoystickInput);
                    joystickThread = new Thread(joystickThreadStart);

                    activeThread = true;

                    SetJoystick();
                });

                return _GetJoystickData_ButtonClickCommand;
            }
        }

        ICommand _StopJoystickData_ButtonClickCommand;
        public ICommand StopJoystickData_ButtonClickCommand
        {
            get
            {
                _StopJoystickData_ButtonClickCommand = new DelegateCommand(obj =>
                {
                    activeThread = false;
                    joystickThread.Join();
                });

                return _StopJoystickData_ButtonClickCommand;
            }
        }



        public void SetJoystick()
        {
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad,
                        DeviceEnumerationFlags.AllDevices))
                joystickGuid = deviceInstance.InstanceGuid;

            // If Gamepad not found, look for a Joystick
            if (joystickGuid == Guid.Empty)
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick,
                        DeviceEnumerationFlags.AllDevices))
                    joystickGuid = deviceInstance.InstanceGuid;

            // If Joystick not found, throws an error
            if (joystickGuid == Guid.Empty)
            {
                Console.WriteLine("No joystick/Gamepad found.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            // Instantiate the joystick
            joystick = new Joystick(directInput, joystickGuid);

            Console.WriteLine("Found Joystick/Gamepad with GUID: {0}", joystickGuid);

            // Query all suported ForceFeedback effects
            var allEffects = joystick.GetEffects();
            foreach (var effectInfo in allEffects)
                Console.WriteLine("Effect available {0}", effectInfo.Name);

            // Set BufferSize in order to use buffered data.
            joystick.Properties.BufferSize = 128;

            // Acquire the joystick
            joystick.Acquire();

            joystickThread.Start();
        }

        private void GetJoystickInput()
        {
            // Poll events from joystick
            while (activeThread)
            {
                joystick.Poll();
                var datas = joystick.GetBufferedData();
                foreach (var state in datas)
                {
                    ConvertJoystickData(state);
                    Console.WriteLine(state);
                }                   
            }
        }

        private void ConvertJoystickData(JoystickUpdate state)
        {
            switch(state.Offset)
            {
                case JoystickOffset.X:
                    X = state.Value;
                    break;
                case JoystickOffset.Y:
                    Y = state.Value;
                    break;
                case JoystickOffset.Z:
                    Z = state.Value;
                    break;
                case JoystickOffset.RotationZ:
                    RotationZ = state.Value;
                    break;
                case JoystickOffset.PointOfViewControllers0:
                    PointOfViewControllers0 = state.Value;
                    break;
                case JoystickOffset.Buttons0:
                    Button0 = state.Value;
                    break;
                case JoystickOffset.Buttons1:
                    Button1 = state.Value;
                    break;
                case JoystickOffset.Buttons2:
                    Button2 = state.Value;
                    break;
                case JoystickOffset.Buttons3:
                    Button3 = state.Value;
                    break;
                case JoystickOffset.Buttons4:
                    Button4 = state.Value;
                    break;
                case JoystickOffset.Buttons5:
                    Button5 = state.Value;
                    break;
                case JoystickOffset.Buttons6:
                    Button6 = state.Value;
                    break;
                case JoystickOffset.Buttons7:
                    Button7 = state.Value;
                    break;
                case JoystickOffset.Buttons8:
                    Button8 = state.Value;
                    break;
                case JoystickOffset.Buttons9:
                    Button9 = state.Value;
                    break;
                case JoystickOffset.Buttons10:
                    Button10 = state.Value;
                    break;
                case JoystickOffset.Buttons11:
                    Button11 = state.Value;
                    break;
            }
        }

        #region Property Changed Event

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event if needed.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}

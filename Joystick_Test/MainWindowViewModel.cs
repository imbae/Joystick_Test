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

        #region private 

        private int _x;
        private int _y;
        private int _z;
        private int _rotationX;
        private int _rotationY;
        private int _rotationZ;
        private int _sliders0;
        private int _sliders1;
        private int _pointOfViewControllers0;
        private int _pointOfViewControllers1;
        private int _pointOfViewControllers2;
        private int _pointOfViewControllers3;
        private int _button0;
        private int _button1;
        private int _button2;
        private int _button3;
        private int _button4;
        private int _button5;
        private int _button6;
        private int _button7;
        private int _button8;
        private int _button9;
        private int _button10;
        private int _button11;
        private int _button12;
        private int _button13;
        private int _button14;
        private int _button15;
        private int _button16;
        private int _button17;
        private int _button18;
        private int _button19;
        private int _button20;
        private int _button21;
        private int _button22;
        private int _button23;
        private int _button24;
        private int _button25;
        private int _button26;
        private int _button27;
        private int _button28;
        private int _button29;
        private int _button30;
        private int _button31;
        private int _button32;
        private int _button33;
        private int _button34;
        private int _button35;
        private int _button36;
        private int _button37;
        private int _button38;
        private int _button39;
        private int _button40;
        private int _button41;
        private int _button42;
        private int _button43;
        private int _button44;
        private int _button45;
        private int _button46;
        private int _button47;
        private int _button48;
        private int _button49;
        private int _button50;
        private int _button51;
        private int _button52;
        private int _button53;
        private int _button54;
        private int _button55;
        private int _button56;
        private int _button57;
        private int _button58;
        private int _button59;
        private int _button60;
        private int _button61;
        private int _button62;
        private int _button63;
        private int _button64;
        private int _button65;
        private int _button66;
        private int _button67;
        private int _button68;
        private int _button69;
        private int _button70;
        private int _button71;
        private int _button72;
        private int _button73;
        private int _button74;
        private int _button75;
        private int _button76;
        private int _button77;
        private int _button78;
        private int _button79;
        private int _button80;
        private int _button81;
        private int _button82;
        private int _button83;
        private int _button84;
        private int _button85;
        private int _button86;
        private int _button87;
        private int _button88;
        private int _button89;
        private int _button90;
        private int _button91;
        private int _button92;
        private int _button93;
        private int _button94;
        private int _button95;
        private int _button96;
        private int _button97;
        private int _button98;
        private int _button99;
        private int _button100;
        private int _button101;
        private int _button102;
        private int _button103;
        private int _button104;
        private int _button105;
        private int _button106;
        private int _button107;
        private int _button108;
        private int _button109;
        private int _button110;
        private int _button111;
        private int _button112;
        private int _button113;
        private int _button114;
        private int _button115;
        private int _button116;
        private int _button117;
        private int _button118;
        private int _button119;
        private int _button120;
        private int _button121;
        private int _button122;
        private int _button123;
        private int _button124;
        private int _button125;
        private int _button126;
        private int _button127;
        private int _velocityX;
        private int _velocityY;
        private int _velocityZ;
        private int _angularVelocityX;
        private int _angularVelocityY;
        private int _angularVelocityZ;
        private int _velocitySliders0;
        private int _velocitySliders1;
        private int _accelerationX;
        private int _accelerationY;
        private int _accelerationZ;
        private int _angularAccelerationX;
        private int _angularAccelerationY;
        private int _angularAccelerationZ;
        private int _accelerationSliders0;
        private int _accelerationSliders1;
        private int _forceX;
        private int _forceY;
        private int _forceZ;
        private int _torqueX;
        private int _torqueY;
        private int _torqueZ;
        private int _forceSliders0;
        private int _forceSliders1;

        #endregion

        public int X { get { return _x; } set { _x = value; OnPropertyChanged("X"); } }
        public int Y { get { return _y; } set { _y = value; OnPropertyChanged("Y"); } }
        public int Z { get { return _z; } set { _z = value; OnPropertyChanged("Z"); } }

        public int RotationX { get { return _rotationX; } set { _rotationX = value; OnPropertyChanged("RotationX"); } }
        public int RotationY { get { return _rotationY; } set { _rotationY = value; OnPropertyChanged("RotationY"); } }
        public int RotationZ { get { return _rotationZ; } set { _rotationZ = value; OnPropertyChanged("RotationZ"); } }

        public int Sliders0 { get { return _sliders0; } set { _sliders0 = value; OnPropertyChanged("Sliders0"); } }
        public int Sliders1 { get { return _sliders1; } set { _sliders1 = value; OnPropertyChanged("Sliders1"); } }

        public int PointOfViewControllers0 { get { return _pointOfViewControllers0; } set { _pointOfViewControllers0 = value; OnPropertyChanged("PointOfViewControllers0"); } }
        public int PointOfViewControllers1 { get { return _pointOfViewControllers1; } set { _pointOfViewControllers1 = value; OnPropertyChanged("PointOfViewControllers1"); } }
        public int PointOfViewControllers2 { get { return _pointOfViewControllers2; } set { _pointOfViewControllers2 = value; OnPropertyChanged("PointOfViewControllers2"); } }
        public int PointOfViewControllers3 { get { return _pointOfViewControllers3; } set { _pointOfViewControllers3 = value; OnPropertyChanged("PointOfViewControllers3"); } }

        public int Button0 { get { return _button0; } set { _button0 = value; OnPropertyChanged("Button0"); } }
        public int Button1 { get { return _button1; } set { _button1 = value; OnPropertyChanged("Button1"); } }
        public int Button2 { get { return _button2; } set { _button2 = value; OnPropertyChanged("Button2"); } }
        public int Button3 { get { return _button3; } set { _button3 = value; OnPropertyChanged("Button3"); } }
        public int Button4 { get { return _button4; } set { _button4 = value; OnPropertyChanged("Button4"); } }
        public int Button5 { get { return _button5; } set { _button5 = value; OnPropertyChanged("Button5"); } }
        public int Button6 { get { return _button6; } set { _button6 = value; OnPropertyChanged("Button6"); } }
        public int Button7 { get { return _button7; } set { _button7 = value; OnPropertyChanged("Button7"); } }
        public int Button8 { get { return _button8; } set { _button8 = value; OnPropertyChanged("Button8"); } }
        public int Button9 { get { return _button9; } set { _button9 = value; OnPropertyChanged("Button9"); } }
        public int Button10 { get { return _button10; } set { _button10 = value; OnPropertyChanged("Button10"); } }
        public int Button11 { get { return _button11; } set { _button11 = value; OnPropertyChanged("Button11"); } }
        public int Button12 { get { return _button12; } set { _button12 = value; OnPropertyChanged("Button12"); } }
        public int Button13 { get { return _button13; } set { _button13 = value; OnPropertyChanged("Button13"); } }
        public int Button14 { get { return _button14; } set { _button14 = value; OnPropertyChanged("Button14"); } }
        public int Button15 { get { return _button15; } set { _button15 = value; OnPropertyChanged("Button15"); } }
        public int Button16 { get { return _button16; } set { _button16 = value; OnPropertyChanged("Button16"); } }
        public int Button17 { get { return _button17; } set { _button17 = value; OnPropertyChanged("Button17"); } }
        public int Button18 { get { return _button18; } set { _button18 = value; OnPropertyChanged("Button18"); } }
        public int Button19 { get { return _button19; } set { _button19 = value; OnPropertyChanged("Button19"); } }
        public int Button20 { get { return _button20; } set { _button20 = value; OnPropertyChanged("Button20"); } }
        public int Button21 { get { return _button21; } set { _button21 = value; OnPropertyChanged("Button21"); } }
        public int Button22 { get { return _button22; } set { _button22 = value; OnPropertyChanged("Button22"); } }
        public int Button23 { get { return _button23; } set { _button23 = value; OnPropertyChanged("Button23"); } }
        public int Button24 { get { return _button24; } set { _button24 = value; OnPropertyChanged("Button24"); } }
        public int Button25 { get { return _button25; } set { _button25 = value; OnPropertyChanged("Button25"); } }
        public int Button26 { get { return _button26; } set { _button26 = value; OnPropertyChanged("Button26"); } }
        public int Button27 { get { return _button27; } set { _button27 = value; OnPropertyChanged("Button27"); } }
        public int Button28 { get { return _button28; } set { _button28 = value; OnPropertyChanged("Button28"); } }
        public int Button29 { get { return _button29; } set { _button29 = value; OnPropertyChanged("Button29"); } }
        public int Button30 { get { return _button30; } set { _button30 = value; OnPropertyChanged("Button30"); } }
        public int Button31 { get { return _button31; } set { _button31 = value; OnPropertyChanged("Button31"); } }
        public int Button32 { get { return _button32; } set { _button32 = value; OnPropertyChanged("Button32"); } }
        public int Button33 { get { return _button33; } set { _button33 = value; OnPropertyChanged("Button33"); } }
        public int Button34 { get { return _button34; } set { _button34 = value; OnPropertyChanged("Button34"); } }
        public int Button35 { get { return _button35; } set { _button35 = value; OnPropertyChanged("Button35"); } }
        public int Button36 { get { return _button36; } set { _button36 = value; OnPropertyChanged("Button36"); } }
        public int Button37 { get { return _button37; } set { _button37 = value; OnPropertyChanged("Button37"); } }
        public int Button38 { get { return _button38; } set { _button38 = value; OnPropertyChanged("Button38"); } }
        public int Button39 { get { return _button39; } set { _button39 = value; OnPropertyChanged("Button39"); } }
        public int Button40 { get { return _button40; } set { _button40 = value; OnPropertyChanged("Button40"); } }
        public int Button41 { get { return _button41; } set { _button41 = value; OnPropertyChanged("Button41"); } }
        public int Button42 { get { return _button42; } set { _button42 = value; OnPropertyChanged("Button42"); } }
        public int Button43 { get { return _button43; } set { _button43 = value; OnPropertyChanged("Button43"); } }
        public int Button44 { get { return _button44; } set { _button44 = value; OnPropertyChanged("Button44"); } }
        public int Button45 { get { return _button45; } set { _button45 = value; OnPropertyChanged("Button45"); } }
        public int Button46 { get { return _button46; } set { _button46 = value; OnPropertyChanged("Button46"); } }
        public int Button47 { get { return _button47; } set { _button47 = value; OnPropertyChanged("Button47"); } }
        public int Button48 { get { return _button48; } set { _button48 = value; OnPropertyChanged("Button48"); } }
        public int Button49 { get { return _button49; } set { _button49 = value; OnPropertyChanged("Button49"); } }
        public int Button50 { get { return _button50; } set { _button50 = value; OnPropertyChanged("Button50"); } }
        public int Button51 { get { return _button51; } set { _button51 = value; OnPropertyChanged("Button51"); } }
        public int Button52 { get { return _button52; } set { _button52 = value; OnPropertyChanged("Button52"); } }
        public int Button53 { get { return _button53; } set { _button53 = value; OnPropertyChanged("Button53"); } }
        public int Button54 { get { return _button54; } set { _button54 = value; OnPropertyChanged("Button54"); } }
        public int Button55 { get { return _button55; } set { _button55 = value; OnPropertyChanged("Button55"); } }
        public int Button56 { get { return _button56; } set { _button56 = value; OnPropertyChanged("Button56"); } }
        public int Button57 { get { return _button57; } set { _button57 = value; OnPropertyChanged("Button57"); } }
        public int Button58 { get { return _button58; } set { _button58 = value; OnPropertyChanged("Button58"); } }
        public int Button59 { get { return _button59; } set { _button59 = value; OnPropertyChanged("Button59"); } }
        public int Button60 { get { return _button60; } set { _button60 = value; OnPropertyChanged("Button60"); } }
        public int Button61 { get { return _button61; } set { _button61 = value; OnPropertyChanged("Button61"); } }
        public int Button62 { get { return _button62; } set { _button62 = value; OnPropertyChanged("Button62"); } }
        public int Button63 { get { return _button63; } set { _button63 = value; OnPropertyChanged("Button63"); } }
        public int Button64 { get { return _button64; } set { _button64 = value; OnPropertyChanged("Button64"); } }
        public int Button65 { get { return _button65; } set { _button65 = value; OnPropertyChanged("Button65"); } }
        public int Button66 { get { return _button66; } set { _button66 = value; OnPropertyChanged("Button66"); } }
        public int Button67 { get { return _button67; } set { _button67 = value; OnPropertyChanged("Button67"); } }
        public int Button68 { get { return _button68; } set { _button68 = value; OnPropertyChanged("Button68"); } }
        public int Button69 { get { return _button69; } set { _button69 = value; OnPropertyChanged("Button69"); } }
        public int Button70 { get { return _button70; } set { _button70 = value; OnPropertyChanged("Button70"); } }
        public int Button71 { get { return _button71; } set { _button71 = value; OnPropertyChanged("Button71"); } }
        public int Button72 { get { return _button72; } set { _button72 = value; OnPropertyChanged("Button72"); } }
        public int Button73 { get { return _button73; } set { _button73 = value; OnPropertyChanged("Button73"); } }
        public int Button74 { get { return _button74; } set { _button74 = value; OnPropertyChanged("Button74"); } }
        public int Button75 { get { return _button75; } set { _button75 = value; OnPropertyChanged("Button75"); } }
        public int Button76 { get { return _button76; } set { _button76 = value; OnPropertyChanged("Button76"); } }
        public int Button77 { get { return _button77; } set { _button77 = value; OnPropertyChanged("Button77"); } }
        public int Button78 { get { return _button78; } set { _button78 = value; OnPropertyChanged("Button78"); } }
        public int Button79 { get { return _button79; } set { _button79 = value; OnPropertyChanged("Button79"); } }
        public int Button80 { get { return _button80; } set { _button80 = value; OnPropertyChanged("Button80"); } }
        public int Button81 { get { return _button81; } set { _button81 = value; OnPropertyChanged("Button81"); } }
        public int Button82 { get { return _button82; } set { _button82 = value; OnPropertyChanged("Button82"); } }
        public int Button83 { get { return _button83; } set { _button83 = value; OnPropertyChanged("Button83"); } }
        public int Button84 { get { return _button84; } set { _button84 = value; OnPropertyChanged("Button84"); } }
        public int Button85 { get { return _button85; } set { _button85 = value; OnPropertyChanged("Button85"); } }
        public int Button86 { get { return _button86; } set { _button86 = value; OnPropertyChanged("Button86"); } }
        public int Button87 { get { return _button87; } set { _button87 = value; OnPropertyChanged("Button87"); } }
        public int Button88 { get { return _button88; } set { _button88 = value; OnPropertyChanged("Button88"); } }
        public int Button89 { get { return _button89; } set { _button89 = value; OnPropertyChanged("Button89"); } }
        public int Button90 { get { return _button90; } set { _button90 = value; OnPropertyChanged("Button90"); } }
        public int Button91 { get { return _button91; } set { _button91 = value; OnPropertyChanged("Button91"); } }
        public int Button92 { get { return _button92; } set { _button92 = value; OnPropertyChanged("Button92"); } }
        public int Button93 { get { return _button93; } set { _button93 = value; OnPropertyChanged("Button93"); } }
        public int Button94 { get { return _button94; } set { _button94 = value; OnPropertyChanged("Button94"); } }
        public int Button95 { get { return _button95; } set { _button95 = value; OnPropertyChanged("Button95"); } }
        public int Button96 { get { return _button96; } set { _button96 = value; OnPropertyChanged("Button96"); } }
        public int Button97 { get { return _button97; } set { _button97 = value; OnPropertyChanged("Button97"); } }
        public int Button98 { get { return _button98; } set { _button98 = value; OnPropertyChanged("Button98"); } }
        public int Button99 { get { return _button99; } set { _button99 = value; OnPropertyChanged("Button99"); } }
        public int Button100 { get { return _button100; } set { _button100 = value; OnPropertyChanged("Button100"); } }
        public int Button101 { get { return _button101; } set { _button101 = value; OnPropertyChanged("Button101"); } }
        public int Button102 { get { return _button102; } set { _button102 = value; OnPropertyChanged("Button102"); } }
        public int Button103 { get { return _button103; } set { _button103 = value; OnPropertyChanged("Button103"); } }
        public int Button104 { get { return _button104; } set { _button104 = value; OnPropertyChanged("Button104"); } }
        public int Button105 { get { return _button105; } set { _button105 = value; OnPropertyChanged("Button105"); } }
        public int Button106 { get { return _button106; } set { _button106 = value; OnPropertyChanged("Button106"); } }
        public int Button107 { get { return _button107; } set { _button107 = value; OnPropertyChanged("Button107"); } }
        public int Button108 { get { return _button108; } set { _button108 = value; OnPropertyChanged("Button108"); } }
        public int Button109 { get { return _button109; } set { _button109 = value; OnPropertyChanged("Button109"); } }
        public int Button110 { get { return _button110; } set { _button110 = value; OnPropertyChanged("Button110"); } }
        public int Button111 { get { return _button111; } set { _button111 = value; OnPropertyChanged("Button111"); } }
        public int Button112 { get { return _button112; } set { _button112 = value; OnPropertyChanged("Button112"); } }
        public int Button113 { get { return _button113; } set { _button113 = value; OnPropertyChanged("Button113"); } }
        public int Button114 { get { return _button114; } set { _button114 = value; OnPropertyChanged("Button114"); } }
        public int Button115 { get { return _button115; } set { _button115 = value; OnPropertyChanged("Button115"); } }
        public int Button116 { get { return _button116; } set { _button116 = value; OnPropertyChanged("Button116"); } }
        public int Button117 { get { return _button117; } set { _button117 = value; OnPropertyChanged("Button117"); } }
        public int Button118 { get { return _button118; } set { _button118 = value; OnPropertyChanged("Button118"); } }
        public int Button119 { get { return _button119; } set { _button119 = value; OnPropertyChanged("Button119"); } }
        public int Button120 { get { return _button120; } set { _button120 = value; OnPropertyChanged("Button120"); } }
        public int Button121 { get { return _button121; } set { _button121 = value; OnPropertyChanged("Button121"); } }
        public int Button122 { get { return _button122; } set { _button122 = value; OnPropertyChanged("Button122"); } }
        public int Button123 { get { return _button123; } set { _button123 = value; OnPropertyChanged("Button123"); } }
        public int Button124 { get { return _button124; } set { _button124 = value; OnPropertyChanged("Button124"); } }
        public int Button125 { get { return _button125; } set { _button125 = value; OnPropertyChanged("Button125"); } }
        public int Button126 { get { return _button126; } set { _button126 = value; OnPropertyChanged("Button126"); } }
        public int Button127 { get { return _button127; } set { _button127 = value; OnPropertyChanged("Button127"); } }

        public int VelocityX { get { return _velocityX; } set { _velocityX = value; OnPropertyChanged("VelocityX"); } }
        public int VelocityY { get { return _velocityY; } set { _velocityY = value; OnPropertyChanged("VelocityY"); } }
        public int VelocityZ { get { return _velocityZ; } set { _velocityZ = value; OnPropertyChanged("VelocityZ"); } }

        public int AngularVelocityX { get { return _angularVelocityX; } set { _angularVelocityX = value; OnPropertyChanged("AngularVelocityX"); } }
        public int AngularVelocityY { get { return _angularVelocityY; } set { _angularVelocityY = value; OnPropertyChanged("AngularVelocityY"); } }
        public int AngularVelocityZ { get { return _angularVelocityZ; } set { _angularVelocityZ = value; OnPropertyChanged("AngularVelocityZ"); } }

        public int VelocitySliders0 { get { return _velocitySliders0; } set { _velocitySliders0 = value; OnPropertyChanged("VelocitySliders0"); } }
        public int VelocitySliders1 { get { return _velocitySliders1; } set { _velocitySliders1 = value; OnPropertyChanged("VelocitySliders1"); } }

        public int AccelerationX { get { return _accelerationX; } set { _accelerationX = value; OnPropertyChanged("AccelerationX"); } }
        public int AccelerationY { get { return _accelerationY; } set { _accelerationY = value; OnPropertyChanged("AccelerationY"); } }
        public int AccelerationZ { get { return _accelerationZ; } set { _accelerationZ = value; OnPropertyChanged("AccelerationZ"); } }

        public int AngularAccelerationX { get { return _angularAccelerationX; } set { _angularAccelerationX = value; OnPropertyChanged("AngularAccelerationX"); } }
        public int AngularAccelerationY { get { return _angularAccelerationY; } set { _angularAccelerationY = value; OnPropertyChanged("AngularAccelerationY"); } }
        public int AngularAccelerationZ { get { return _angularAccelerationZ; } set { _angularAccelerationZ = value; OnPropertyChanged("AngularAccelerationZ"); } }

        public int AccelerationSliders0 { get { return _accelerationSliders0; } set { _accelerationSliders0 = value; OnPropertyChanged("AccelerationSliders0"); } }
        public int AccelerationSliders1 { get { return _accelerationSliders1; } set { _accelerationSliders1 = value; OnPropertyChanged("AccelerationSliders1"); } }

        public int ForceX { get { return _forceX; } set { _forceX = value; OnPropertyChanged("ForceX"); } }
        public int ForceY { get { return _forceY; } set { _forceY = value; OnPropertyChanged("ForceY"); } }
        public int ForceZ { get { return _forceZ; } set { _forceZ = value; OnPropertyChanged("ForceZ"); } }

        public int TorqueX { get { return _torqueX; } set { _torqueX = value; OnPropertyChanged("TorqueX"); } }
        public int TorqueY { get { return _torqueY; } set { _torqueY = value; OnPropertyChanged("TorqueY"); } }
        public int TorqueZ { get { return _torqueZ; } set { _torqueZ = value; OnPropertyChanged("TorqueZ"); } }

        public int ForceSliders0 { get { return _forceSliders0; } set { _forceSliders0 = value; OnPropertyChanged("ForceSliders0"); } }
        public int ForceSliders1 { get { return _forceSliders1; } set { _forceSliders1 = value; OnPropertyChanged("ForceSliders1"); } }


        #endregion

        public MainWindowViewModel()
        {
            directInput = new DirectInput();
            joystickGuid = Guid.Empty;
        }

        public void ThreadDispose()
        {
            activeThread = false;

            if(joystickThread != null && joystickThread.IsAlive)
            {
                joystickThread.Join();
            }            
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

            if (joystickGuid == Guid.Empty)
                foreach (var deviceInstance in directInput.GetDevices(DeviceClass.GameControl,
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
                }
            }
        }

        private void ConvertJoystickData(JoystickUpdate state)
        {
            switch (state.Offset)
            {
                case JoystickOffset.X: X = state.Value; break;
                case JoystickOffset.Y: Y = state.Value; break;
                case JoystickOffset.Z: Z = state.Value; break;

                case JoystickOffset.RotationX: RotationX = state.Value; break;
                case JoystickOffset.RotationY: RotationY = state.Value; break;
                case JoystickOffset.RotationZ: RotationZ = state.Value; break;

                case JoystickOffset.Sliders0: Sliders0 = state.Value; break;
                case JoystickOffset.Sliders1: Sliders1 = state.Value; break;

                case JoystickOffset.PointOfViewControllers0: PointOfViewControllers0 = state.Value; break;
                case JoystickOffset.PointOfViewControllers1: PointOfViewControllers1 = state.Value; break;
                case JoystickOffset.PointOfViewControllers2: PointOfViewControllers2 = state.Value; break;
                case JoystickOffset.PointOfViewControllers3: PointOfViewControllers3 = state.Value; break;

                case JoystickOffset.Buttons0: Button0 = state.Value; break;
                case JoystickOffset.Buttons1: Button1 = state.Value; break;
                case JoystickOffset.Buttons2: Button2 = state.Value; break;
                case JoystickOffset.Buttons3: Button3 = state.Value; break;
                case JoystickOffset.Buttons4: Button4 = state.Value; break;
                case JoystickOffset.Buttons5: Button5 = state.Value; break;
                case JoystickOffset.Buttons6: Button6 = state.Value; break;
                case JoystickOffset.Buttons7: Button7 = state.Value; break;
                case JoystickOffset.Buttons8: Button8 = state.Value; break;
                case JoystickOffset.Buttons9: Button9 = state.Value; break;
                case JoystickOffset.Buttons10: Button10 = state.Value; break;
                case JoystickOffset.Buttons11: Button11 = state.Value; break;
                case JoystickOffset.Buttons12: Button12 = state.Value; break;
                case JoystickOffset.Buttons13: Button13 = state.Value; break;
                case JoystickOffset.Buttons14: Button14 = state.Value; break;
                case JoystickOffset.Buttons15: Button15 = state.Value; break;
                case JoystickOffset.Buttons16: Button16 = state.Value; break;
                case JoystickOffset.Buttons17: Button17 = state.Value; break;
                case JoystickOffset.Buttons18: Button18 = state.Value; break;
                case JoystickOffset.Buttons19: Button19 = state.Value; break;
                case JoystickOffset.Buttons20: Button20 = state.Value; break;
                case JoystickOffset.Buttons21: Button21 = state.Value; break;
                case JoystickOffset.Buttons22: Button22 = state.Value; break;
                case JoystickOffset.Buttons23: Button23 = state.Value; break;
                case JoystickOffset.Buttons24: Button24 = state.Value; break;
                case JoystickOffset.Buttons25: Button25 = state.Value; break;
                case JoystickOffset.Buttons26: Button26 = state.Value; break;
                case JoystickOffset.Buttons27: Button27 = state.Value; break;
                case JoystickOffset.Buttons28: Button28 = state.Value; break;
                case JoystickOffset.Buttons29: Button29 = state.Value; break;
                case JoystickOffset.Buttons30: Button30 = state.Value; break;
                case JoystickOffset.Buttons31: Button31 = state.Value; break;
                case JoystickOffset.Buttons32: Button32 = state.Value; break;
                case JoystickOffset.Buttons33: Button33 = state.Value; break;
                case JoystickOffset.Buttons34: Button34 = state.Value; break;
                case JoystickOffset.Buttons35: Button35 = state.Value; break;
                case JoystickOffset.Buttons36: Button36 = state.Value; break;
                case JoystickOffset.Buttons37: Button37 = state.Value; break;
                case JoystickOffset.Buttons38: Button38 = state.Value; break;
                case JoystickOffset.Buttons39: Button39 = state.Value; break;
                case JoystickOffset.Buttons40: Button40 = state.Value; break;
                case JoystickOffset.Buttons41: Button41 = state.Value; break;
                case JoystickOffset.Buttons42: Button42 = state.Value; break;
                case JoystickOffset.Buttons43: Button43 = state.Value; break;
                case JoystickOffset.Buttons44: Button44 = state.Value; break;
                case JoystickOffset.Buttons45: Button45 = state.Value; break;
                case JoystickOffset.Buttons46: Button46 = state.Value; break;
                case JoystickOffset.Buttons47: Button47 = state.Value; break;
                case JoystickOffset.Buttons48: Button48 = state.Value; break;
                case JoystickOffset.Buttons49: Button49 = state.Value; break;
                case JoystickOffset.Buttons50: Button50 = state.Value; break;
                case JoystickOffset.Buttons51: Button51 = state.Value; break;
                case JoystickOffset.Buttons52: Button52 = state.Value; break;
                case JoystickOffset.Buttons53: Button53 = state.Value; break;
                case JoystickOffset.Buttons54: Button54 = state.Value; break;
                case JoystickOffset.Buttons55: Button55 = state.Value; break;
                case JoystickOffset.Buttons56: Button56 = state.Value; break;
                case JoystickOffset.Buttons57: Button57 = state.Value; break;
                case JoystickOffset.Buttons58: Button58 = state.Value; break;
                case JoystickOffset.Buttons59: Button59 = state.Value; break;
                case JoystickOffset.Buttons60: Button60 = state.Value; break;
                case JoystickOffset.Buttons61: Button61 = state.Value; break;
                case JoystickOffset.Buttons62: Button62 = state.Value; break;
                case JoystickOffset.Buttons63: Button63 = state.Value; break;
                case JoystickOffset.Buttons64: Button64 = state.Value; break;
                case JoystickOffset.Buttons65: Button65 = state.Value; break;
                case JoystickOffset.Buttons66: Button66 = state.Value; break;
                case JoystickOffset.Buttons67: Button67 = state.Value; break;
                case JoystickOffset.Buttons68: Button68 = state.Value; break;
                case JoystickOffset.Buttons69: Button69 = state.Value; break;
                case JoystickOffset.Buttons70: Button70 = state.Value; break;
                case JoystickOffset.Buttons71: Button71 = state.Value; break;
                case JoystickOffset.Buttons72: Button72 = state.Value; break;
                case JoystickOffset.Buttons73: Button73 = state.Value; break;
                case JoystickOffset.Buttons74: Button74 = state.Value; break;
                case JoystickOffset.Buttons75: Button75 = state.Value; break;
                case JoystickOffset.Buttons76: Button76 = state.Value; break;
                case JoystickOffset.Buttons77: Button77 = state.Value; break;
                case JoystickOffset.Buttons78: Button78 = state.Value; break;
                case JoystickOffset.Buttons79: Button79 = state.Value; break;
                case JoystickOffset.Buttons80: Button80 = state.Value; break;
                case JoystickOffset.Buttons81: Button81 = state.Value; break;
                case JoystickOffset.Buttons82: Button82 = state.Value; break;
                case JoystickOffset.Buttons83: Button83 = state.Value; break;
                case JoystickOffset.Buttons84: Button84 = state.Value; break;
                case JoystickOffset.Buttons85: Button85 = state.Value; break;
                case JoystickOffset.Buttons86: Button86 = state.Value; break;
                case JoystickOffset.Buttons87: Button87 = state.Value; break;
                case JoystickOffset.Buttons88: Button88 = state.Value; break;
                case JoystickOffset.Buttons89: Button89 = state.Value; break;
                case JoystickOffset.Buttons90: Button90 = state.Value; break;
                case JoystickOffset.Buttons91: Button91 = state.Value; break;
                case JoystickOffset.Buttons92: Button92 = state.Value; break;
                case JoystickOffset.Buttons93: Button93 = state.Value; break;
                case JoystickOffset.Buttons94: Button94 = state.Value; break;
                case JoystickOffset.Buttons95: Button95 = state.Value; break;
                case JoystickOffset.Buttons96: Button96 = state.Value; break;
                case JoystickOffset.Buttons97: Button97 = state.Value; break;
                case JoystickOffset.Buttons98: Button98 = state.Value; break;
                case JoystickOffset.Buttons99: Button99 = state.Value; break;
                case JoystickOffset.Buttons100: Button100 = state.Value; break;
                case JoystickOffset.Buttons101: Button101 = state.Value; break;
                case JoystickOffset.Buttons102: Button102 = state.Value; break;
                case JoystickOffset.Buttons103: Button103 = state.Value; break;
                case JoystickOffset.Buttons104: Button104 = state.Value; break;
                case JoystickOffset.Buttons105: Button105 = state.Value; break;
                case JoystickOffset.Buttons106: Button106 = state.Value; break;
                case JoystickOffset.Buttons107: Button107 = state.Value; break;
                case JoystickOffset.Buttons108: Button108 = state.Value; break;
                case JoystickOffset.Buttons109: Button109 = state.Value; break;
                case JoystickOffset.Buttons110: Button110 = state.Value; break;
                case JoystickOffset.Buttons111: Button111 = state.Value; break;
                case JoystickOffset.Buttons112: Button112 = state.Value; break;
                case JoystickOffset.Buttons113: Button113 = state.Value; break;
                case JoystickOffset.Buttons114: Button114 = state.Value; break;
                case JoystickOffset.Buttons115: Button115 = state.Value; break;
                case JoystickOffset.Buttons116: Button116 = state.Value; break;
                case JoystickOffset.Buttons117: Button117 = state.Value; break;

                case JoystickOffset.VelocityX: VelocityX = state.Value; break;
                case JoystickOffset.VelocityY: VelocityY = state.Value; break;
                case JoystickOffset.VelocityZ: VelocityZ = state.Value; break;

                case JoystickOffset.AngularVelocityX: AngularVelocityX = state.Value; break;
                case JoystickOffset.AngularVelocityY: AngularVelocityY = state.Value; break;
                case JoystickOffset.AngularVelocityZ: AngularVelocityZ = state.Value; break;

                case JoystickOffset.VelocitySliders0: VelocitySliders0 = state.Value; break;
                case JoystickOffset.VelocitySliders1: VelocitySliders1 = state.Value; break;

                case JoystickOffset.AccelerationX: AccelerationX = state.Value; break;
                case JoystickOffset.AccelerationY: AccelerationY = state.Value; break;
                case JoystickOffset.AccelerationZ: AccelerationZ = state.Value; break;

                case JoystickOffset.AngularAccelerationX: AngularAccelerationX = state.Value; break;
                case JoystickOffset.AngularAccelerationY: AngularAccelerationY = state.Value; break;
                case JoystickOffset.AngularAccelerationZ: AngularAccelerationZ = state.Value; break;

                case JoystickOffset.AccelerationSliders0: AccelerationSliders0 = state.Value; break;
                case JoystickOffset.AccelerationSliders1: AccelerationSliders1 = state.Value; break;

                case JoystickOffset.ForceX: ForceX = state.Value; break;
                case JoystickOffset.ForceY: ForceY = state.Value; break;
                case JoystickOffset.ForceZ: ForceZ = state.Value; break;

                case JoystickOffset.TorqueX: TorqueX = state.Value; break;
                case JoystickOffset.TorqueY: TorqueY = state.Value; break;
                case JoystickOffset.TorqueZ: TorqueZ = state.Value; break;

                case JoystickOffset.ForceSliders0: ForceSliders0 = state.Value; break;
                case JoystickOffset.ForceSliders1: ForceSliders1 = state.Value; break;
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

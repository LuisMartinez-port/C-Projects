using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFirstSprint2_Luis;

namespace SkateboardWPF.ViewModels
{
    public class ViewModelSkateBoard : BaseViewModel
    {
        public Skateboards skateboard;

        //as of now the only property that will be constantly changed in a manner that is reflected on the wpf is the current speed

        public int Currentspeed
        {
            get { return skateboard.CurrentSpeed; }

            
        }

        public int Maxspeed {
            get { return skateboard.TopSpeed; }
        }
        //the property IsOffGround when you pop the board makes the buttons disappear for moving so it seems redundant to represent that with data binding 
        //especially since to be able to move the board again you need to do a trick which lands the board

       
         public void Pushoff()
        {
            skateboard.PushOff();
            RaisePropertyChangedEvent("Currentspeed");
        }

        public void PushForward(int amount)
        {
            skateboard.PushForward(amount);
            RaisePropertyChangedEvent("Currentspeed");
        }

        public void SlowDown(int amount)
        {
            skateboard.SlowDown(amount);
            RaisePropertyChangedEvent("Currentspeed");
        }
        
      public void Ollie()
        {
            skateboard.Ollie();
        }
        
        public void Kickflip() {  skateboard.Kickflip(); }

        public void DolphinFlip() { skateboard.DolphinFlip(); }


        public ViewModelSkateBoard(Skateboards skateboard)
        {
            this.skateboard = skateboard;
        }

       

    }
}

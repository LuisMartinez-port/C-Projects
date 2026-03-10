using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TestFirstSprint2_Luis
{
    public abstract class Skateboards
    {
        public Wheels wheels = new Wheels();

        public Trucks trucks = new Trucks();

        public Deck Deck = new Deck();

        public int CurrentSpeed { get; set; }

        public int TopSpeed;

        public int defaultPushSpeed;

        //have a method in abstract class that is like a "running start" it will set are rolling to true and give a decent current speed. 


        public Skateboards()
        {
            Deck.isOffGround = false;

            trucks.TruckTightness = 60;

            wheels.areRolling = false;

        }

        public string aboutBoardBuild()
        {
            return $"The Board in front of you has a {Deck.About()} The wheels on the board are {wheels.About()} The trucks on the board {trucks.About()}"; // call in the different abouts from the other classes and bring them together here to have an about for the skateboard itself

        }

        public string aboutBoardPerformance()
        {
            return $"\nYour Board is currently moving at a speed of {CurrentSpeed}, and has a top speed of {TopSpeed}\n";
        }

        public string PushOff()
        {
            if (wheels.areRolling == true)
            {
                return "You're already rolling!";

            }

            else
            {
                wheels.areRolling = true;

                return "You're now rolling";
                
            }

        }

      

        public string PushForward(int value)
        {
            if (wheels.areRolling == false)
            {
                return "You arent rolling yet! Make sure to be on your board before trying anything else";  }


            else if (Deck.isOffGround == true)
            {
                return "You must land a trick before you do anything else";
            }

            else
            {
                if (trucks.TruckTightness > 100)
                {
                    return "Your trucks are WAY too tight, Loosen them before you do anything else!!";
                }


                else if (trucks.TruckTightness < 30)
                {
                        return "Your trucks are WAY too loose, tighten them before you do anything else!!";
                }


                else
                {


                    if (CurrentSpeed + value > TopSpeed)
                    {
                        return$"You cant go past a speed of {TopSpeed}";

                    }


                    else
                    {
                        CurrentSpeed += value;

                        if (trucks.TruckTightness > 70)
                        {
                            return $"You are now moving at a speed of {CurrentSpeed}, but your trucks are a bit too tight, they have a tightness of {trucks.TruckTightness}\nYou should loosen them a bit";

                        }


                        else if (trucks.TruckTightness < 40)
                        {
                            return $"You are now moving at a speed of {CurrentSpeed}, but your trucks are a bit too loose, they have a tightness of {trucks.TruckTightness}\nYou should tighten them a bit";
                        }


                        else
                        {
                            return $"You are now moving at a speed of {CurrentSpeed}";
                        }




                    }
                }


            }


        }

       

        public string SlowDown(int value)
        {
            if (wheels.areRolling == false)
            {
                return "You arent rolling yet! Make sure to be on your board before trying anything else";
            }


            else if (Deck.isOffGround == true)
            {
                return "You must land a trick before you do anything else";
            }



            else
            {
                if (trucks.TruckTightness > 100)
                {
                    return "Your trucks are WAY too tight, Loosen them before you do anything else!!";
                }


                else if (trucks.TruckTightness < 30)
                {
                    return "Your trucks are WAY too loose, tighten them before you do anything else!!";
                }




                else
                {


                    if (CurrentSpeed - value  <  0)
                    {
                        CurrentSpeed = 60 ;
                        return "You're not moving anymore";
                       

                    }


                    else
                    {
                        CurrentSpeed -= value;

                        if (trucks.TruckTightness > 70)
                        {
                            return $"You are now moving at a speed of {CurrentSpeed}, but your trucks are a bit too tight, they have a tightness of {trucks.TruckTightness}\nYou should loosen them a bit";

                        }


                        else if (trucks.TruckTightness < 40)
                        {
                            return $"You are now moving at a speed of {CurrentSpeed}, but your trucks are a bit too loose, they have a tightness of {trucks.TruckTightness}\nYou should tighten them a bit";
                        }


                        else
                        {
                            return $"You are now moving at a speed of {CurrentSpeed}";
                        }




                    }
                }


            }

        }

        public string Kickflip()
        {
            if (trucks.TruckTightness > 100 || trucks.TruckTightness < 30)
            {
               return"Woah!! Fix your trucks before you try a trick";
            }

            else
            {



                if (Deck.isOffGround)
                {
                    Deck.isOffGround = false;
                    return "You just landed a Kickflip!";
                    
                }
                else
                {
                    return "You cant do a Kickflip! You need to get the board off the ground first";


                }

            }

        }

        //make sure to add it so that these cant work if truck tightness is too tight

        public string DolphinFlip()
        {
            if (trucks.TruckTightness > 100 || trucks.TruckTightness < 30)
            {
                return "Woah, fix your trucks before you try a trick";
            }

            else
            {

                if (Deck.isOffGround)
                {
                    Deck.isOffGround = false;
                    return "You just landed a Dolphin Flip!";         
                }
                else
                {
                    return"You cant do a Dolphin Flip! You need to get the board off the ground first";


                }
            }

        }

        public string Ollie()
        {
            if (wheels.areRolling == false)
            {
               return "You arent rolling yet! Make sure to be on your board before trying anything else";
            }

            else if (trucks.TruckTightness > 100 || trucks.TruckTightness < 30)
            {
                return"Woah, fix your trucks before you try a trick";
            }


            else {
                Deck.Pop();
            //dont let user push or slow down until trick is landed
            return"Your board is now in the air! Do a Trick!"; }
            
        }


    }
}

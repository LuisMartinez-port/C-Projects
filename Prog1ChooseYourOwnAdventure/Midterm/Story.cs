using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    public class Story
    {
        //This is the class where I keep an array of all my dialouge
        public string[] contentArray = new string[61]
        {
            "After years of research on mysterious treasures you decide to chase after them yourself, longing to find the truth\n",
            "You begin your journey to the Golden Grotto,\nit's a treacherous journey the whole way through.\n\nAs you arrive, you're greeted by a groundskeeper.\nHe asks for your name:\n " ,
            "but I must warn you, these caves can be a bit dangerous, you must be incredibly lucky, especially if you're alone,\n\nI would advise you to pick an exploration partner.\n\nHere's a list of some of the most reliable explorers, but be warned they are very competetive when it comes to the value of their treasure.",
            "If you would like to explore alongside Tyrone please press 1,\n\nTo explore alongside Kyle please press 2,\n\nAnd if you would like to explore with Alex please press 3:\n",
            "Ah you decided to explore with ",
            "You must first pick a path to explore, but be warned one path is more dangerous than the other.\nIf I knew which path was safer I would love to inform you but unfortunately im clueless.\n ",
            "Press 1 if you would like to explore the cave of Lost Souls.\nPress 2 if you would like to explore the Tavern of the Newts Alloy:",
            ", an amazing choice, I wish you the best of luck.\n\nJust follow the signs and you'll be at The ",
            "\nAs you approach the Cave of Lost Souls, an eerie mist cloaks the entrance, shrouding the path in an unsettling silence broken only by the distant echoes of a haunting melody.\n",
            "\nAs you venture into the Cave you notice inscriptions on the wall.\n\nYou run your hand over them to inspect them.\n\nAs you do so you notice a door open.\n\nWould you like to enter the door? (Enter yes or no)",
            "\nAs you walk into the freshly opened door you trip on an old travelers skeleton\n\nAs you're on the ground you see two directions to go\n\nChoose left or right\n\n",
            "\nYou consider entering but upon further thought you think its too risky\n\nYou continue to walk down the main path",
            "\nAs you enter the left passage way, you notice a pedestal in the middle of the room.\n\nYou approach cautiously and ensure to slowly grab the Treasure.\n\nYou read the inscription on it, it reads The Spectral Lantern.\n\nYou place the treasure in your bag and head back to the main path",
            "\nAs you enter the right passage way, you notice a pedestal in the middle of the room.\n\nYou approach cautiously and ensure to slowly grab the Treasure.\n\nAs you reach out and touch the Treasure, it suddenly retracts and disappears.\n\nYou're forced to go back to the main passage way.",
            "\nYou peer into the right passage way and are immediately met with a giant spider.\n\nYou suffer a nasty bite.\n\nYou reluctantly head back to the main path\n",
            "\nAmidst the winding forest path, the rustling leaves whisper tales of the elusive Tavern of the Newts Alloy, its flickering lanterns casting a warm glow that beckons you forward.\n",
            "\nYou wander deeper into the cave.\n\nThe floor is a mud like substance.\nYou trip and notice a trapdoor on the floor.\n\nWould you like to enter the TrapDoor (Type yes or no)\n",
            "\nAs you enter the trapdoor you're met with two crawlspaces.\n\nWould you like to go to the left or the right?\n",
            "\nYou decide to leave the Trapdoor alone.\n\nBetter safe than sorry.",
            "\nYou decide to crawl to the Right\n\nYou're met with what seems like a deadend after minutes of crawling.\n\nAs you reposition your hands to turn around and go back you feel a flask.\n\nYou read the lettering and its the Alchemist's Elixir Flask.\n\nYou take it and return to the main path\n",
            "\nAs you begin crawling to the left you make a series of turns\n\nYou crawl for what feels like hours until you finally reach the end.\n\nYou push through only to be right back on the main path\n",
            "\nAs you begin crawling to the left you make two turns before you're face to face with the alchemist himself.\n\nHe accuses you of stealing his flask so he throws a potion at you.\n\nYou dont remember much but you wake up back on the main path with some injuries\n",
            "\nYou continue to walk through the main passage way.\n\nYou're met by a bright Green arrow on the floor pointing into another Door. \n\nDo you enter the door(Type yes or no)\n",
            "\nYou decide to trust your gut and walk into the door.\n\nYou're once again met with the choice of left or right (Type left or right).\n",
            "\nYou decide to not trust a random arrow drawn by some stranger.\n\nYou ignore the door and move down the path.\n",
            "\nAs you step to the left side you see a lone mirror in the room.\n\nYou're not sure why but everything in your body is telling you to smash it.\n\nYou throw a rock at it and pick up a shard... You can feel its presence\n\n... The Whispering Shard\n\nYou grab hold of it and return to the main path\n",
            "\nYou take large steps in order to seal your fate as soon as possible.\n\nYou look around for anything that may be treasure...But this is a normal room.\n",
            "\nYou slowly creep into the right side... You notice the door is closing behind you with a creak loud enough you're not sure it will open again.\n\nYou sprint back for the door... diving through at the last second.\n\nIt clipped your ankle and are hurt",
            "\nYou continue walking down the main path,\n\nEventually you see a small waterfall with a possible path behind it.\n\nWould you like to enter the path? (type yes or no)\n",
            "\nYou decide to go through the passage.\n\nYou pass through the water and almost slip.\n\nThere is two slides, either left or right.\n\nWhich do you take? (Type left or right)\n",
            "\nYou decide you're not in the mood to get wet.\n\nYou skip this passage and continue forward.\n",
            "\nYou take the left side slide.\n\nIt is a very straight slide...You magically appear back outside with The Newt's Satchel of Infinite Provisions in your hand.\n\nYou dont question it and continue forward\n",
            "\nAs you go down the right slide it seems like you'll be stuck there forever.\n\nBut when you least expect it you're teleported back to the main path.\n",
            "\nYou go down the right slide but it collapses right under you.\n\nYou try and prepare for the landing but you dont know when you'll hit the ground.\n\nSuddenly you teleport back to the main path, but the landing really hurts both of your feet.\n",
            "\nYou continue down the same path and are met with suspicious vines hanging on the wall.\n\nYou clear them away with your hand...\nRevealing a space you might be able to squeeze through.\n\nDo you want to enter? (Type yes or no)\n",
            "\nYou decide to force yourself into the opening... it's a tight squeeze but you made it.\n\n theres two ways to go left or right (Type Left or Right)\n",
            "\nYou dont think you can fit and dont want to risk getting stuck.\n\nYou play it safe and move forward.\n",
            "\nYou make your way to the right...It's so dark you cant see anything.\n\nYou reach your hand out and touch the shadow?? \n\nYou grab ahold of it and squeeze it down to the size of your palm.\n\nYou realize you have the Veil of Shadows and make your way back to the main path.\n",
            "\nYou begin scooting to the left, it's pitch black and you cant see anything.\n\nYou feel around for a while but ultimately find nothing.\n\nYou give up and go back to the main path empty handed.\n",
            "\nAs you make your way to the left you feel something touch you.\n\nYou mistake it for the treasure and lunge for it.\n\nIts pitch black so you dont know what you just squeezed...but whatever it is bit you so hard it sent you scurrying to the main path once more.\n",
            "\nAs you tread down the main path you run into a seemingly normal door.\n\nBut it seems almost too normal.\n\nWould you like to enter the door? (Type yes or no)\n",
            "\nYou decide to trust this suspicious door and walk inside.\n\nIt seems normal, you see two more doors.\\One on your Left and one on your right. (Type left or right).\n",
            "\nThe door cant be trusted in your mind.\n\nYou walk past it and continue down the main path.\n",
            "\nAs you walk into the right side door you're greeted with a stereotypical treasure chest.\n\nInside of it is The Amphibians Brew Stein.\n\nYou shrug and head back to the main path.\n",
            "\nYou enter the left side door and the simplicity of the door makes sense to you.\n\nIt's just an empty room...bone dry.\n\nyou turn around and go back to the main path.\n",
            "\nYou go into the left side door and as you take a step inside a large rock falls from the ceiling.\n\nIt hurts really bad but it makes you laugh at how simple the door really was.\n",
            "\nYou grow tired and decide to lean against a wall for a moment.\n\nYou almost fall backwards into a secret passage.\n\nDo you enter the revolving secret passage? (Type yes or no)\n",
            "\nYou decide to flip backwards into the hidden room.\n\nIt's really dark but you can make out two switches.\n\nThey're labeled option one and option two (Type left for option one, Type right for option two).\n",
            "\nYou just want to get out of here as soon as possible.\n\nYou leave behind the secret door and head towards the exit in the distance where you'll meet back up with your partner.\n\n",
            "\nYou switch the lever that says option one.\n\nAfter a long and dramatic delay the Echoing Chalice falls from the ceiling and thankfully you catch it.\n\nYou head back out and go to meet up with your partner.\n",
            "\nYou switch the lever that says option two.\n\nAfter a long and dramatic delay the Echoing Chalice falls from the ceiling.\n\nUnfortunately you miss the catch and it shatters when it hits the ground.\n\nDissapointed you head back out and meet with your partner.\n",
            "\nYou switch the lever that says option two.\n\nAfter a long and dramatic delay the Echoing Chalice falls from the ceiling.\n\nYou dive for it and unfortunately you overshoot.\n\nIt breaks right over your head...hurting a lot.\n\nYou head to the main path and go to meet up with your partner,\n",
            "\nYou grow hungry... You set your bag down to take out a snack.\n\nYou just so happened to place your bag on a pressureplate which opened a secret door.\n\nWould you like to enter? (Type yes or no)\n",
            "\nYou make sure your bag is steady before you head is as you dont want to be trapped inside.\n\n You poke your head in and see two buttons.\n\nA sign reads 'You have 5 seconds after pushing it to check your luck then return back to the main path.\n\n Would you like to hit the left button or the right button (Type left or right).\n",
            "\nYou dont want to risk your bag falling.\n\nYou collect your things and head back to your partner.\n",
            "\nYou hit the left side button and spring into the door that opens.\n\nYou see a treasure and grab it without thinking.\n\nYou have to dive to make it but you're back on the main path.\n\n You look at the treasure and its the Gilded Lute of Melodic Enchantment.\n\nWith a smile you leave to meet with your partner.\n",
            "\nYou get ready to run as you click the right button.\n\nYou take one step before realizing the room is empty.\n\nYou backtrack with time to spare and go meet with your partner.\n",
            "\nYou get ready to dash for the treasure as you click the right button.\n\nYou take two steps before you realize theres nothing.\n\nYou backtrack and have to dive to return to the main path on time.\n\nYou smack your head on the closing door causing severe pain but you make it out.\n",
            "Oh? You dont want to make any money off these treasures?\n\nI guess that means...\n I WIN!",
            "You leave the cave, your treasure in hand.\n ",
            "The auction's about to start. One of us is going to be a winner tonight"

        };
    }
}

using System;   //Console.WriteLine
//      ".ReadKey
using System.Diagnostics; //StopWatch
using System.IO;//StreamWriter
using System.Threading;

using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace PlatformerGame
{
    class Entry
    {
        [STAThread]
        public static void Main(string[] aArgs)
        {
            Vector2i activeResolution = new Vector2i(800, 600);
            RenderWindow rw = new RenderWindow(new VideoMode((uint)activeResolution.X, (uint)activeResolution.Y), "2DEngine");
            rw.Position = new Vector2i(0, 0);
            rw.SetActive(true);
            rw.SetVerticalSyncEnabled(true);
            rw.Closed += rw_Closed;
            
            Stopwatch timer = new Stopwatch();
            timer.Start();
            long elapsed = 10;
            DateTime tempTime1, tempTime2;
            Screen lTestScreen = new Screen();
            using (StreamWriter sw = new StreamWriter("LOG.txt"))
                while (rw.IsOpen)
                {
                    rw.DispatchEvents();

                    //TODO > 
                    // This is borked for the tiles and IDK why. Currently this is disabled so I don't
                    // see the flashing tiles and popup menus, they are annoying.
                    //
                    // I think maybe I could ask Nathan Bean about this, see if he has any idea's for why
                    // this is happening. Maybe talk to matt about it and see his opinion.
                    //
                    // Never mind, now it is happening regardless.
                    //
                    // The log i created does not show that the draw times are lagging, nor are the update speeds.
                    // Maybe it has to do with something someone once told me about: double buffering. I should
                    // look into this specifically to see if maybe that is what the root is.
                    if (elapsed > 10)
                    {
                        timer.Restart();

                        tempTime1 = DateTime.Now;
                        sw.WriteLine("    DRAW START TIME : {0}", tempTime1.Millisecond);
                        lTestScreen.update(rw, elapsed);
                        //game.update(rw, elapsed);
                        tempTime2 = DateTime.Now;
                        sw.WriteLine("      DRAW END TIME : {0}", tempTime2.Millisecond);
                        sw.WriteLine("  DRAW ELAPSED TIME : {0}", tempTime2.Millisecond - tempTime1.Millisecond);

                        tempTime1 = DateTime.Now;
                        sw.WriteLine("  UPDATE START TIME : {0}", tempTime1.Millisecond);
                        lTestScreen.draw(rw, elapsed);
                        //game.draw(rw, elapsed);
                        tempTime2 = DateTime.Now;
                        sw.WriteLine("    UPDATE END TIME : {0}", tempTime2.Millisecond);
                        sw.WriteLine("UPDATE ELAPSED TIME : {0}", tempTime2.Millisecond - tempTime1.Millisecond);
                        sw.WriteLine(); 
                    }

                    elapsed = timer.ElapsedMilliseconds;
                }

            Console.WriteLine("\nPlease press any key to exit.");
            Console.ReadKey();
        }

        static void rw_Closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }
    }
}
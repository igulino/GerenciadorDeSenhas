using System.Drawing;
using System.Reflection;
using System.Windows.Input;
using Microsoft.AspNetCore.Components.Web;

namespace RandomPos
{
    public class RandomPassword {
        
        public void Sla(){
            MouseEventArgs mouseEvent = new MouseEventArgs();
            var cartoonX = mouseEvent.ScreenX;
            var cartoony = mouseEvent.ScreenY;


            System.Console.WriteLine(cartoonX);
        }

        //Point position = Mouse.GetPosition(displayArea);
    }
    
}
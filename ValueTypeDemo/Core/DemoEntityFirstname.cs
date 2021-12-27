namespace ConsoleMenue
{
    using EasyPrototyping.Entity;

    using System;
    using System.Threading;
    using System.Windows;

    public class DemoEntityFirstname
    {
        public void CreateEntity()
        {
            Console.WriteLine("\nCreate empty Entity Value Object");

            Firstname entity = new Firstname();
            if (entity != null && string.IsNullOrEmpty(entity.Value) == true)
            {
                MessageBox.Show($"{entity.Value}\n{entity.PhoneticCode}");
            }

            Console.WriteLine("\nCreate Firstname Value Object");
            Firstname entity1 = new Firstname("gerhard");
            if (entity1 != null && string.IsNullOrEmpty(entity1.Value) == false)
            {
                MessageBox.Show($"Firstname: {entity1.Value}\nSoundEx:{entity1.PhoneticCode}\nFirstCharUpper:{entity1.FirstCharUpper}");
            }

            Thread.Sleep(1000);
        }
    }
}

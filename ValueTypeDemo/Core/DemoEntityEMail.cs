namespace ConsoleMenue
{
    using EasyPrototyping.Entity;

    using System;
    using System.Threading;
    using System.Windows;

    public class DemoEntityEMail
    {
        public void CreateEntity()
        {
            Console.WriteLine("\nCreate empty Entity EMail Value Object");

            Email email = new Email();
            if (email != null)
            {
                if (email.IsConfirmed == false)
                {
                    MessageBox.Show("No content");
                }
            }

            Console.WriteLine("\nCreate Entity EMail Value Object with valid Mail-Address");
            Email email1 = new Email("gerhard.ahrens@lifeprojects.de");
            if (email1 != null)
            {
                MessageBox.Show($"{email1.Value}\nIsConfirmed={email1.IsConfirmed}");
            }

            Console.WriteLine("\nCreate Entity EMail Value Object with not valid Mail-Address");
            Email email2 = new Email("gerhard.ahrens@lifeprojects#de");
            if (email2 != null)
            {
                MessageBox.Show($"{email2.Value}\nIsConfirmed={email2.IsConfirmed}");
            }

            Thread.Sleep(1000);
        }

        public void DemoB()
        {
            Console.WriteLine("\nDemo B");
            Thread.Sleep(1000);
        }
    }
}

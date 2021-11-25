using EasyPrototyping.DomainType;

using System.Windows.Forms;

public class Program
{
    private static void Main(string[] args)
    {
        Email email = new Email();
        if (email != null)
        {
            if (email.IsConfirmed == false)
            {
                MessageBox.Show("No content");
            }
        }

        Email email1 = new Email("gerhard.ahrens@lifeprojects.de");
        if (email1 != null)
        {
            MessageBox.Show(email1.Value);
        }

        Firstname firstName = new Firstname("gerhard");

    }
}

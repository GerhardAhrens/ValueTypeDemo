﻿using EasyPrototyping.Entity;

using System.Windows;

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
        if (firstName != null)
        {
            MessageBox.Show($"{firstName.Value}\n{firstName.PhoneticCode}");
        }

        Address adr1 = new Address("Deutschland","68195","Musterstadt","Musterstrasse");
        if (adr1 != null)
        {
            Address adr2 = new Address("Deutschland", "68195", "Musterstadt", "Musterstrasse");
            if (adr1 == adr2)
            {
                Address adr3 = (Address)adr1.Clone();
            }
        }

    }
}

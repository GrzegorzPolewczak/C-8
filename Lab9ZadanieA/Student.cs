using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab9ZadanieA
{
    public class Student : IDisposable
    {
        public Student()
        {
            MessageBox.Show("Pobrane zasoby niepamięciowe");
        }

        ~Student()
        {
            MessageBox.Show("Zwalnianie zasobów niepamięciowych w finalizatorze");
        }

        public void Dispose()
        {
            MessageBox.Show("Zwalnianie zasobów niepamięciowych w Dispose");
           // GC.SuppressFinalize(this);
        }
    }
}

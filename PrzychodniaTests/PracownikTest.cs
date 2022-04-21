using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrzychodniaFinal.Models;
using PrzychodniaFinal.Services;
using Xunit;

namespace PrzychodniaTests
{
    public class PracownikTest
    {
        [Fact]
        public void IsPracownikValid_ForNullPracownik_ReturnFalse()
        {
            
            // Arrange
            Pracownicy pracownicy = null;

            // Act
            bool result = PracownicyService.IsPracownikValid(pracownicy);

            // Assert
            Assert.False(result);
        }
        [Fact]
        public void IsPracownikValid_ForNullPracownikPesel_ReturnFalse()
        {

            // Arrange
            Pracownicy pracownicy = new Pracownicy()
            {
                Pesel = null,
                Imie = "Konrad",
                Nazwisko = "Kowalski",
            };

            // Act
            bool result = PracownicyService.IsPracownikValid(pracownicy);

            // Assert
            Assert.False(result);
        }
        [Fact]
        public void IsPracownikValid_ForCorrectData_ReturnTrue()
        {

            // Arrange
            Pracownicy pracownicy = new Pracownicy()
            {
                Pesel = "12345678998",
                Imie = "Ahmed",
                Nazwisko = "Habibi",
            };

            // Act
            bool result = PracownicyService.IsPracownikValid(pracownicy);

            // Assert
            Assert.True(result);
        }
    }
}

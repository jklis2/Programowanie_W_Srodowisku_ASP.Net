using System;
using System.Collections.Generic;
using PrzychodniaFinal.Models;
using PrzychodniaFinal.services;
using Xunit;

namespace PrzychodniaTests
{
    public class PacjentTests
    {
        public static IEnumerable<object[]> TestItemsDataNotOk =>
            new List<object[]>
            {
                new object[] {
                    new Pacjenci()
                    {
                        Imie = "",
                        Pesel = "12345678901",
                        Nazwisko = "Nowak"

                    }
                },new object[] {
                    new Pacjenci()
                    {
                        Imie = "Kamil",
                        Pesel = "12345678",
                        Nazwisko = "Œlimak"

                    }
                },new object[] {
                    new Pacjenci()
                    {
                        Imie = "Karol",
                        Pesel = null, 
                        Nazwisko = "Kowal"
                    }
                }
            }; 
        public static IEnumerable<object[]> TestItemsDataOk =>
            new List<object[]>
            {
                new object[] {
                    new Pacjenci()
                    {
                        Imie = "Olaf",
                        Pesel = "12345678931",
                        Nazwisko = "Nowak"

                    }
                },new object[] {
                    new Pacjenci()
                    {
                        Imie = "Kamil",
                        Pesel = "12345678921",
                        Nazwisko = "Œlimak"

                    }
                },new object[] {
                    new Pacjenci()
                    {
                        Imie = "Karol",
                        Pesel = "12345678911",
                        Nazwisko = "Kowal"
                    }
                }
            };
        [Theory]
        [MemberData(nameof(TestItemsDataNotOk))]
        public void IsPacjentValid_ForInvalidData_ReturnFalse(Pacjenci pacjenci)
        {
            // Arrage


            // Act
            bool result = PacjenciService.IsPacjentValid(pacjenci);

            // Assert
            Assert.False(result);
        }
        [Theory]
        [MemberData(nameof(TestItemsDataOk))]
        public void IsPacjentValid_ForInvalidData_ReturnTrue(Pacjenci pacjenci)
        {
            // Arrage


            // Act
            bool result = PacjenciService.IsPacjentValid(pacjenci);

            // Assert
            Assert.True(result);
        }
    }
}

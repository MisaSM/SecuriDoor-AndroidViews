using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VistasSecuriDoor.Models;

namespace VistasSecuriDoor.Data
{
    public class UsersData {
        public static ObservableCollection<UsersModel> ShowUsers() {
            return new ObservableCollection<UsersModel>() {
                new UsersModel() {
                    Id = 1,
                    Name = "Jorge",
                    Password = "password",
                    IdRol = 1
                },
                new UsersModel() {
                    Id = 2,
                    Name = "Sofia",
                    Password = "password",
                    IdRol = 2
                },
                new UsersModel() {
                    Id = 3,
                    Name = "Cesar",
                    Password = "password",
                    IdRol = 2
                }
            };
        }
    }
}

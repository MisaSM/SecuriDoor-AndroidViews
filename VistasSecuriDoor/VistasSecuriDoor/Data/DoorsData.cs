using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VistasSecuriDoor.Models;
using VistasSecuriDoor.ViewModels;

namespace VistasSecuriDoor.Data
{
    public class DoorsData
    {
        public static ObservableCollection<DoorsModel> ShowDoors()
        {
            return new ObservableCollection<DoorsModel>()
            {
                new DoorsModel()
                {
                    DoorName = "Oficina",
                    DoorLocation = "Empresa",
                    DoorState = false
                },
                new DoorsModel() {
                    DoorName = "Bodega",
                    DoorLocation = "Empresa",
                    DoorState = true
                },
                new DoorsModel() {
                    DoorName = "LabCisco",
                    DoorLocation = "Escuela",
                    DoorState = true
                },
                new DoorsModel()
                {
                    DoorName = "Aula magna",
                    DoorLocation = "Escuela",
                    DoorState = false
                },
                new DoorsModel()
                {
                    DoorName = "Estudio",
                    DoorLocation = "Casa",
                    DoorState = true
                }
                };
            }
        }
}

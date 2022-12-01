﻿using MotorTransportCompany_MVVP.Model.Entities;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorTransportCompany_MVVP.Model.DAOs
{
    internal class MechanicsDAO
    {
        static string connectionString = "server=localhost;port=3306;username=root;password=root;database=motortransportcompany";


        public List<Mechanic> GetAll()
        {
            List<Mechanic> mechanics = new List<Mechanic>();
            MySqlConnection connaction = new MySqlConnection(connectionString);
            connaction.Open();

            MySqlCommand command = new MySqlCommand("SELECT id_mechanic, id_department, name, surname, patronymic, birthday, age, id_sex, passport FROM `mechanics`", connaction);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Mechanic mech = new Mechanic
                    {
                        Id = reader.GetInt32(0),
                        Department_id = reader.GetInt32(1),
                        Name = reader.GetString(2),
                        Surname = reader.GetString(3),
                        Patronymic = reader.GetString(4),
                        BirthdayDate = reader.GetDateTime(5),
                        Age = reader.GetInt32(6),
                        IdSex = reader.GetInt32(7),
                        PassportNumber = reader.GetInt32(8)
                    };
                    mechanics.Add(mech);
                }
            }
            connaction.Close();
            return  mechanics;
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace MetroApp.ClassHelper
{
    internal class SelectSQL
    {

        public void loadElementToComboBox(string stringQuery, string column, System.Windows.Controls.ComboBox myBox)
        {
            List<string> columnValues = new List<string> { "Не выбрано" };
            columnValues.AddRange(GetColumnValues(stringQuery, column));
            myBox.ItemsSource = columnValues;
        }

        public List<string> GetColumnValues(string query, string columnName)
        {
            List<string> columnValues = new List<string>();

            SqlConnection myCon = new SqlConnection(@"Data Source=DESKTOP-2U3E4EP\SQLEXPRESS;Initial Catalog=MetroDB_VKR;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            myCon.Open();
            using (SqlCommand command = new SqlCommand(query, myCon))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    object columnValueObject = reader.GetValue(reader.GetOrdinal(columnName));
                    string columnValue = columnValueObject != DBNull.Value ? columnValueObject.ToString() : "";
                    columnValues.Add(columnValue);
                }
            }
            return columnValues;
        }
    }
}

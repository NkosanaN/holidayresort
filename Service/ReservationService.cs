using Model;
using System.Data;

namespace Service
{
    public  partial class DataHandler
    {
        private Reservation GetReservationFromDataRow(DataRow row)
        {
            return new Reservation
            {
                Id = (int)row["Id"],
                Name = row["Name"].ToString(),
                Surname = row["Surname"].ToString(),
                TelNumber = row["TelNumber"].ToString(),
                ReservationType = row["ReservationType"].ToString(),
                StartDate = (DateTime)row["StartDate"],
                EndDate = (DateTime)row["EndDate"],
            };
        }
        public async Task<List<Reservation>> ReservationListGet()
        {
            var sql = "exec sp_reservation_data @Mode=0  ";

            var dt = Util.Select(sql);
            var list = new List<Reservation>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetReservationFromDataRow(row));
            }
            return list;
        }
        public async Task<Reservation> ReservationGetSingle(int Id)
        {
            var sql = $"exec sp_reservation_data @Mode=1, @id={Id}";

            var dt = Util.Select(sql);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            var r = GetReservationFromDataRow(dt.Rows[0]);
            return r;
        }
        public async Task<bool> AddReservation(Reservation data)
        {
            var sql = $"exec sp_reservation_process @Mode=0 ," +
             $"@Name='{data.Name}'," +
             $"@Surname = '{data.Surname}', " +
             $"@TelNumber = '{data.TelNumber}'," +
             $"@ReservationType ='{data.ReservationType}' ," +
             $"@StartDate ='{data.StartDate}' ," +
             $"@EndDate ='{data.EndDate}'";
            return Util.Execute(sql);
        }
        public async Task<bool> UpdateReservation(Reservation data)
        {
            var sql = $"exec sp_reservation_process @Mode=1 ," +
                $"@Id='{data.Id}'," +
                $"@Name='{data.Name}'," +
                $"@Surname = '{data.Surname}', " +
                $"@TelNumber = '{data.TelNumber}'," +
                $"@ReservationType ='{data.ReservationType}' ," +
                $"@StartDate ='{data.StartDate}' ," +
                $"@EndDate ='{data.EndDate}'";
            return Util.Execute(sql);
        }
    }
}
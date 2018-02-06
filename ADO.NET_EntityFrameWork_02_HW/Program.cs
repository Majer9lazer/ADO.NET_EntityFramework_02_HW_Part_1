using ADO.NET_EntityFrameWork_02_HW.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_EntityFrameWork_02_HW
{
    class Program
    {
        static MCS db = new MCS();
        static void Main(string[] args)
        {
            try
            {
                Task_02_03();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
          
        }
        static void Task_02()
        {
            var query = db.newEquipments.Select(s => new
            {
                s.intGarageRoom,
                s.strSerialNo,
                s.TablesManufacturer.strName
            }).ToList();
            foreach (var item in query)
            {
                Console.WriteLine("{0}\n{1}\n{2}",
                    item.intGarageRoom,item.strSerialNo,item.strName);
            }
        }
        static void Task_02_01()
        {
            var query = db.newEquipments.Include(w=>w.TablesModel).Select(s => new
            {
                s.intGarageRoom,
                s.strSerialNo,
                s.TablesManufacturer.strName
            }).ToList();
            //foreach (var item in query)
            //{
            //    Console.WriteLine("{0}\n{1}\n{2}",
            //        item.intGarageRoom, item.strSerialNo, item.strName);
            //}
            Parallel.ForEach(query, item => {
                Console.WriteLine("{0}\n{1}\n{2}",
                   item.intGarageRoom, item.strSerialNo, item.strName);
            });
        }
        static void Task_02_02()
        {
            var query = db.TablesManufacturers.FirstOrDefault(w => w.intManufacturerID == 2);
            //foreach (var item in query)
            //{
            //    Console.WriteLine("{0}\n{1}\n{2}",
            //        item.intGarageRoom, item.strSerialNo, item.strName);
            //}
            db.Entry(query).Collection(c=>c.newEquipments).Load();
            Parallel.ForEach(query.newEquipments, item => {
                Console.WriteLine("{0}\n{1}\n{2}",
                   item.strSerialNo, item.strManufYear, item.intManufacturerID);
            });
        }
        static void Task_02_03()
        {
            Parallel.ForEach(db.TablesManufacturers.ToList(), item => 
            {
                Console.WriteLine("{0}\n{1}\n{2}", item.intManufacturerID,item.strManufacturerChecklistId,item.strName);
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibraryData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "getdata" in both code and config file together.
    public class getdata : Igetdata
    {
        myDBEntities db = new myDBEntities();
        public List<myData> AllData()
        {
            return db.Employees.Select(d => new myData {id =d.Id, name=d.name, image = d.image }).ToList();
        }



        public void Create(myData d)
        {
            Employee emp = new Employee();
            emp.Id = d.id;
            emp.name = d.name;
            emp.image = d.image;
            db.Employees.Add(emp);
            db.SaveChanges();            
         }


        public myData searchData(int x)
        {
            var data = db.Employees.Where(a => a.Id == x).Select(d => new myData { id = d.Id, name = d.name, image = d.image }).FirstOrDefault();

            return data;
        }


        public void update(myData x)
        {
            var data = db.Employees.Where(a => a.Id == x.id).Select(d => new myData { id = d.Id, name = d.name, image = d.image }).FirstOrDefault();
            data.name = x.name;
            data.image = x.image;
            
            db.SaveChanges(); 
            
        }
    }
}

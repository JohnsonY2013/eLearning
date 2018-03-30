using System.Runtime.Serialization;

namespace WCF.REST.Services
{
    [DataContract(Namespace = "http://www.digitcyber.com/")]
    public class Employee
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Department { get; set; }

        [DataMember]
        public string Grade { get; set; }

        public override string ToString()
        {
            return $"ID:\t{Id}\tName:\t{Name}\tGrade:\t{Grade}\tDepartment:\t{Department}";
        }
    }
}

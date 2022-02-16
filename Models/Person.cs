using System.ComponentModel.DataAnnotations;

namespace Ass_6.Models;
public class Person :IComparable{
    
    public int Id{get;set;}
    [Required,MaxLength(50)]
    public string? FirstName{get;set;}
    [Required,MaxLength(50)]
    public string? LastName{get;set;}
    public string Gender{get;set;}
    public DateTime DateOfBirth{get;set;}
    [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
    public string? PhoneNumber{get;set;}
    [MaxLength(10)]
    public string? BirthPlace{get;set;}
    public int Age {
        get{
            return DateTime.Now.Year - DateOfBirth.Year;
        }
    }
    public bool IsGraduated{get;set;}

    public int TotalDays{
        get{
            return (int)(DateTime.Now - DateOfBirth).TotalDays;
        }
    }
    public string FullName{
        get
        {
            return LastName + " " + FirstName;
        }
    }

    public int CompareTo(object? obj)
    {
        return TotalDays.CompareTo(((Person)obj).TotalDays);
    }
}
public class PersonEditModel : Person{
    
    public PersonEditModel(){}
    public PersonEditModel(Person person){
        FirstName = person.FirstName;
        LastName = person.LastName;
        Gender =    person.Gender;
        DateOfBirth = person.DateOfBirth;
        PhoneNumber = person.PhoneNumber;
        BirthPlace = person.BirthPlace;
    }
    public int Index{get;set;}
}
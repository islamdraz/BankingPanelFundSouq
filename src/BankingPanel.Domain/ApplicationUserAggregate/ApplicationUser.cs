using BankingPanel.Domain.Common;
using BankingPanel.Domain.Common.Interfaces;

namespace BankingPanel.Domain.ApplicationUserAggregate;

public class ApplicationUser : AggregateRoot
{
    public string FirstName { get; private set; } 
    public string LastName { get; private set; } 
    public string Email { get; private set; }  
    public bool Active { get; private set; }
    public  List<string> Roles { get;  private  set; } = new ();
    private  string _passwordHash = null!;

    public ApplicationUser(string firstName, string lastName, string email, string passwordHash,List<string> roles, Guid? id = null) : base(id ?? Guid.NewGuid())
      {
        this.Active = true;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this._passwordHash  = passwordHash;
        this.Roles = roles;
    } 


     public bool IsCorrectPasswordHash(string password, IPasswordHasher passwordHasher)
    {
     return passwordHasher.IsCorrectPassword(password, _passwordHash);
    }

    public void ChangePassword(string passwordHash)
    {
        this._passwordHash = passwordHash;
    }
    public void Deactivate()
    {
        this.Active = false;
    }

    public void Reactivate()
    {
        this.Active = true;
    }


    private ApplicationUser() { }
}
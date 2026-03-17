using RentalService.Entities;

namespace RentalService.Service;

public class UserService
{
    private Storage data;
    
    public UserService(Storage dataInput) {
        data = dataInput;
    }

    public void AddUser(User user)
    {
        data.Users.Add(user);
    }

    public User GetUserById(int id)
    {
        return data.Users.FirstOrDefault(u => u.Id == id);
    }

    public List<User> GetAllUsers()
    {
        return data.Users;
    }
    

}
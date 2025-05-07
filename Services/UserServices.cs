
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using itinera_io_backend.Context;
using itinera_io_backend.Models;
using itinera_io_backend.Models.DTOS;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace itinera_io_backend.Services
{
    public class UserServices
    {
        private readonly DataContext _dataContext;

        private readonly IConfiguration _config;

        public UserServices(DataContext dataContext, IConfiguration config)
        {
            _dataContext = dataContext;
            _config = config;
        }

        //Create account
        public async Task<bool> CreateAccount(UserDTO newUser)
        {
            //check if user exis otherwise proceed to account creation
            if (await DoesUserExist(newUser.Email)) return false;

            UserModel userToAdd = new();

            PasswordDTO encryptedPassword = HashPassword(newUser.Password);

            userToAdd.Hash = encryptedPassword.Hash;
            userToAdd.Salt = encryptedPassword.Salt;
            userToAdd.Email = newUser.Email;
            userToAdd.Name= newUser.Name;

            await _dataContext.User.AddAsync(userToAdd);
            return await _dataContext.SaveChangesAsync() != 0; // returns 1 if it has been added and 0 if not

        }

        //returns a true boolean if there is an existing user  
        public async Task<bool> DoesUserExist(string email) => await _dataContext.User.SingleOrDefaultAsync(user => user.Email == email) != null;

        //static because we are not accessing database and doesnt need async 
        private static PasswordDTO HashPassword(string password)
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(64);
            string salt = Convert.ToBase64String(saltBytes);
            string hash;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 310000, HashAlgorithmName.SHA256))
            {
                hash = Convert.ToBase64String(deriveBytes.GetBytes(32));
            }
            //return a new password DTO
            return new PasswordDTO
            {
                Salt = salt,
                Hash = hash
            };
        }

        //returns a token if user exists and password match 
        public async Task<string> Login(UserDTO user)
        {
            UserModel userInDB = await GetUserByUsername(user.Email);

            //if user doesnt exist
            if (userInDB == null)
                return null;

            //check if user entered correct password
            if (!VerifyPassword(user.Password, userInDB.Salt, userInDB.Hash))
            {
                return null;
            }

            //generate the token 

            // return GenerateJWTToken(new List<Claim>()); //same as below
            return GenerateJWTToken([]);
        }

        private string GenerateJWTToken(List<Claim> claims)
        {
            // encrypt the secret key
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
              issuer: "https://itineraioapi-cqapgsgcbschc7hu.westus-01.azurewebsites.net/",
              audience: "https://itineraioapi-cqapgsgcbschc7hu.westus-01.azurewebsites.net/",
              
                // issuer: "http://localhost:5000",
                // audience: "http://localhost:5000",
              claims: claims,
                expires: DateTime.Now.AddMinutes(30),
              signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private async Task<UserModel> GetUserByUsername(string email) => await _dataContext.User.SingleOrDefaultAsync(user => user.Email == email); //returns  the user that is found

        private async Task<UserModel> GetUserById(int id) => await _dataContext.User.SingleOrDefaultAsync(user => user.Id == id); //returns  the user that is found

        private static bool VerifyPassword(string password, string salt, string hash)
        {
            byte[] saltByte = Convert.FromBase64String(salt);
            string checkHash;

            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltByte, 310000, HashAlgorithmName.SHA256))
            {
                checkHash = Convert.ToBase64String(deriveBytes.GetBytes(32));
                return hash == checkHash;
            }
        }

        public async Task <UserInfoDTO> GetUserInfoByEmailAsync (string email)
        {
            var userInDB = await _dataContext.User.SingleOrDefaultAsync(user => user.Email == email);
           
            UserInfoDTO  user = new();
            if (userInDB==null)
                user=null;
            else{
            user.Id = userInDB.Id;
            user.Email= userInDB.Email;
            user.Name = userInDB.Name;
            }
            
            return user;

        }

        public async Task <UserInfoDTO> GetUserInfoByIdAsync (int id)
        {
            var userInDB = await _dataContext.User.SingleOrDefaultAsync(user => user.Id == id);
           
            UserInfoDTO  user = new();
            if (userInDB==null)
                user=null;
            else{
            user.Id = userInDB.Id;
            user.Email= userInDB.Email;
            user.Name = userInDB.Name;
            }
            
            return user;

        }

         public async Task<bool> EditUserAsync(UserInfoDTO user){
            //check if user exis otherwise proceed to account edit
            if (await DoesUserExist(user.Email)) return false;

            var userToEdit = await _dataContext.User.SingleOrDefaultAsync(u => u.Id == user.Id);
            if (userToEdit == null) 
            return false;

            if (userToEdit.Name != user.Name)    // update only when the values are different 
            userToEdit.Name= user.Name;

            if (userToEdit.Email != user.Email)  // update only when the values are different 
            userToEdit.Email = user.Email;
            
            //no use for update since this is already tracking changes 
           return await _dataContext.SaveChangesAsync()!=0;
        }

          public async Task<bool> EditPasswordAsync(ChangePasswordDTO passwordInfo){
            var userInDB = await GetUserById(passwordInfo.UserId);
            if (userInDB == null) 
                return false;

            //check if user entered correct old password
            if (!VerifyPassword(passwordInfo.OldPassword, userInDB.Salt, userInDB.Hash))
            {
                return false;
            }
   
            PasswordDTO newEncryptedPassword = HashPassword(passwordInfo.NewPassword);

            userInDB.Hash = newEncryptedPassword.Hash;
            userInDB.Salt = newEncryptedPassword.Salt;
            
            //no use for update since this is already tracking changes 
           return await _dataContext.SaveChangesAsync()!=0;
        }


    }
}
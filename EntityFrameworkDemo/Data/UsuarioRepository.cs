using System.Linq;

namespace EntityFrameworkDemo.Repository
{
    public class UsuarioRepository
    {       
            ApiDbContext _context;
            public UsuarioRepository(ApiDbContext context)
            {
                _context = context;
            }
            public void Add(Usuario user)
            {
             _context.Add(user);

            }
            public List<Usuario> GetAll() //get não usar SaveChanges
            {
          
            return _context.Usuarios.ToList();

            }
            public Usuario GetById(Guid id)
            {
            return _context.Usuarios.Find(id);                   
            }
            public Usuario Update(Guid id, Usuario updatedUser)
            {
                var user = GetById(id);
                user.Email = updatedUser.Email;
                user.Nome = updatedUser.Nome;
                user.Telefone = updatedUser.Telefone;
                user.Senha = updatedUser.Senha;
                _context.Add(updatedUser);
                return user;
                //SaveChanges colocar apenas no Controllers
            }
        
            public void Delete(Guid id)
            {
                var user = GetById(id);
                _context.Remove(user);
            }
           
        }
    }


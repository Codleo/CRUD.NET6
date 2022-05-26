using EntityFrameworkDemo.Repository;

namespace EntityFrameworkDemo.Services
{
    public class UsuarioService
    {
        public UsuarioRepository _usuarioRepository;
        public UsuarioService(UsuarioRepository Repository)
        {
            _usuarioRepository = Repository;
        }
        public void Create(Usuario user)
        {
            _usuarioRepository.Add(user);
        }
        public List<Usuario> GetUsers()
        {
            return _usuarioRepository.GetAll();
        }
        public Usuario Update(Guid id, Usuario user)
        {
            return _usuarioRepository.Update(id, user);
        }

        public Usuario Getuser(Guid id)
        {
            return _usuarioRepository.GetById(id);
        }

        public void DeleteUser(Guid id)
        {
            _usuarioRepository.Delete(id);
        }

    }
}

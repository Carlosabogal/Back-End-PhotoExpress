using ApiPhotoExpress.Model.DTO;
using ApiPhotoExpress.Model.Entity;
using ApiPhotoExpress.Repository;
using System.Globalization;

namespace ApiPhotoExpress.Service
{
    public class RegisterService
    {
        private RegisterRepository registroRepository;

        public RegisterService(RegisterRepository repository)
        {
            registroRepository = repository;
        }

        public async Task CreateRegister(RegisterRequest request)
        {
            try
            {
                var newRegister = new Register
                {
                    InstitucionSuperior = request.HigherInstitution,
                    DireccionInstitucion = request.InstitutionAddress,
                    NumeroAlumnos = request.NumberStudents,
                    HoraInicio = DateTime.ParseExact(request.StartTime, "HH:mm", CultureInfo.InvariantCulture),
                    ValorServicio = 200
                };

                if (request.ServiceCapGown)
                {
                    newRegister.ValorServicio = 200 + (20 * request.NumberStudents);
                }

                await registroRepository.InsertRegister(newRegister);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating the register: {ex.Message}");
            }
        }
        public async Task<List<Register>> GetRegisters()
        {
            return await registroRepository.GetRegisters();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.Frotas.Domain
{
    public interface IVeiculoRepository
    {
        Task<Veiculo> GetbyId(Guid id);
        Task<List<Veiculo>> GetAll(int pagina, int quantidade);
        Task Add(Veiculo veiculo);
        Task Delete(Veiculo veiculo);
        Task Update(Veiculo veiculo);


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{ //Remarque1: interface generique qui va etre implememente par toutes les autres interfaces qui lui est necessaire 

    //Remarque2: Dans l'interface IAsyncRepository, toutes les méthodes sont marquées avec le mot-clé "async" pour indiquer
    //qu'elles peuvent être exécutées de manière asynchrone.
    //Cela permet d'optimiser les performances de l'application en évitant de bloquer le thread d'exécution
    //pendant l'exécution des opérations de base de données, ce qui peut être une opération coûteuse en termes de temps.
    public interface IAsyncRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> RemoveAsync(TEntity entity);
        Task<IEnumerable<TEntity>> RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
//remarque 3 : Le <IEnumerable<TEntity>> dans l'interface IAsyncRepository est un type générique qui indique que les méthodes de l'interface renvoient des collections d'objets de type TEntity, qui peuvent être de différents types selon l'interface implémentée.

//Par exemple, si l'interface IAsyncRepository<Client> est implémentée, les méthodes de cette interface renverront des collections d'objets Client, donc le type générique sera remplacé par IEnumerable<Client>. Si l'interface IAsyncRepository<Product> est implémentée, les méthodes renverront des collections d'objets Product, donc le type générique sera remplacé par IEnumerable<Product>.

//En utilisant ce type générique, l'interface peut être réutilisée pour travailler avec différentes entités sans avoir à redéfinir les mêmes méthodes pour chaque entité.
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class baseSpecification <T>: ISpecifications<T>
    {
        public baseSpecification(Expression<Func<T, bool>> criteria
       )
        {
            Criteria = criteria;
            
        }

        public baseSpecification()
        {
        
       }

        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;}= new List<Expression<Func<T, object>>>();

      //   public int m {get;}
     protected void AddInclude(Expression<Func<T, object>> includeExpression){
        Includes.Add(includeExpression);
     } 
    }
}  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Linq.Expressions;

namespace Condiciones
{
    /// <summary>
    /// A generic sorter class used to wrap the LINQ OrderBy functions.
    /// </summary>
    /// <typeparam name="T">The <see cref="System.Type"/> of object being sorted.</typeparam>
    public class Sorter<T>
    {
        /// <summary>
        /// Sorts a list of type T.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="prmExpression">The expression defining the parameter to supply to the lambda expression.</param>
        /// <param name="sortExpression">The name of the property on the parameter object to sort by.
        /// <param name="sortDirection">The direction in which to sort the objects.</param>
        /// <returns>The sorted list.</returns>
        public List<T> Sort(IEnumerable<T> list, ParameterExpression prmExpression, string sortExpression, SortDirection sortDirection)
        {
            var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(Expression.Property(prmExpression, sortExpression), typeof(object)), prmExpression);

            return sortDirection == SortDirection.Ascending ? list.AsQueryable<T>().OrderBy<T, object>(lambda).ToList() : list.AsQueryable<T>().OrderByDescending<T, object>(lambda).ToList();
        }

        /// <summary>
        /// Sorts a list of type T.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="prmExpression">The expression defining the parameter to supply to the lambda expression.</param>
        /// <param name="keySelectionExpression">
        /// A <see cref="MemberExpression"/> that identifies a property on an object in the supplied <param name="list"/> that is used to
        /// perform the sort.
        /// </param>
        /// <param name="sortDirection">The direction in which to sort the objects.</param>
        /// <returns>The sorted list.</returns>
        public List<T> Sort(IEnumerable<T> list, ParameterExpression prmExpression, MemberExpression sortExpression, SortDirection sortDirection)
        {
            var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(sortExpression, typeof(object)), prmExpression);

            return sortDirection == SortDirection.Ascending ? list.AsQueryable<T>().OrderBy<T, object>(lambda).ToList() : list.AsQueryable<T>().OrderByDescending<T, object>(lambda).ToList();
        }
    }
}

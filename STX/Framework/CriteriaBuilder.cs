using System;
using System.Linq;
namespace STX
{
    public class CriteriaBuilder
    {

        private string criteriaQuery;
        private string orderByQuery;

        public CriteriaBuilder()
        {
            criteriaQuery = "";
            orderByQuery = "";
        }
        public void AddOrderBy(string field, Ordenation ordenation)
        {
            orderByQuery = " ORDER BY ";
            orderByQuery += field;
            orderByQuery += (ordenation == Ordenation.Asc ? " ASC" : "DESC");
        }
        public void AddWhere(string property, object value, MatchMode mode, CriterionRelation relation = CriterionRelation.None)
        {
            if (criteriaQuery.Length > 0)
            {
                if (relation == CriterionRelation.And)
                {
                    criteriaQuery += " AND ";
                }
                else if (relation == CriterionRelation.Or)
                {
                    criteriaQuery += " OR ";
                }
            }
            else
            {
                criteriaQuery += " WHERE ";
            }
            criteriaQuery += " " + property;
            switch (mode)
            {
                case MatchMode.Different:
                    criteriaQuery += " != ";
                    break;
                case MatchMode.Equals:
                    criteriaQuery += " = ";
                    break;
                case MatchMode.Greater:
                    criteriaQuery += " > ";
                    break;
                case MatchMode.GreaterEqual:
                    criteriaQuery += " >= ";
                    break;
                case MatchMode.Lesser:
                    criteriaQuery += " < ";
                    break;
                case MatchMode.LesserEqual:
                    criteriaQuery += " <= ";
                    break;
                case MatchMode.Like:
                    criteriaQuery += " LIKE ";
                    break;
            }
            if (mode != MatchMode.Like)
            {
                criteriaQuery += " '" + value + "' ";
            }
            else
            {
                criteriaQuery += " '%" + value + "%' ";
            }
        }
        public void AddCustomSqlCriteria(string customCriteria)
        {
            criteriaQuery += customCriteria;
            criteriaQuery += " ";
        }
        public string GetQuery()
        {
            return criteriaQuery;
        }
        public string GetOrderBy()
        {
            return orderByQuery;
        }
    }
    public enum MatchMode : int
    {
        Equals, Like, Greater, Lesser, GreaterEqual, LesserEqual, Different
    }
    public enum CriterionRelation : int
    {
        None, And, Or
    }
    public enum Ordenation : int
    {
        Asc = 0, Desc = 1
    }
}

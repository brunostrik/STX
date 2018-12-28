using System;
using System.Linq;
namespace STX
{
    public class CriteriaBuilder
    {

        private string criteriaQuery;

        public CriteriaBuilder()
        {
            criteriaQuery = "";
        }
        public void Add(string property, object value, MatchMode mode, CriterionRelation relation = CriterionRelation.None)
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
    }
    public enum MatchMode : int
    {
        Equals, Like, Greater, Lesser, GreaterEqual, LesserEqual, Different
    }
    public enum CriterionRelation : int
    {
        None, And, Or
    }
}

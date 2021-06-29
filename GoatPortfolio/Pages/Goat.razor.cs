using System.Linq;

namespace GoatPortfolio.Pages
{
    public partial class Goat
    {
        private bool IsSortedAscending;
        private string CurrentSortColumn;

        public void SortTable(string columnName)
        {
            if (columnName != CurrentSortColumn)
            {
                assets = assets.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                CurrentSortColumn = columnName;
                IsSortedAscending = true;

            }
            else //Sorting against same column but in different direction
            {
                if (IsSortedAscending)
                {
                    assets = assets.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                else
                {
                    assets = assets.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }

                //Toggle this boolean
                IsSortedAscending = !IsSortedAscending;
            }
        }

        public string GetSortStyle(string columnName)
        {
            if (CurrentSortColumn != columnName)
            {
                return string.Empty;
            }
            if (IsSortedAscending)
            {
                return "fa-sort-up";
            }
            else
            {
                return "fa-sort-down";
            }
        }
    }
}
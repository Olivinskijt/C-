using System.Collections.Generic;

public interface IMenuSearch
{
    MenuItem FindItemByName(string name);
    List<MenuItem> FindItemsByCategory(string category);
}

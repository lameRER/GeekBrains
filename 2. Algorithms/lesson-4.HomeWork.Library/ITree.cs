namespace lesson_4.HomeWork.Library
{
    public interface ITree
    {
        TreeNode GetRoot();
        /// <summary>
        /// добавляет узел
        /// </summary>
        /// <param name="value"></param>
        void AddItem(int value);
        /// <summary>
        /// удаляет узел по значению
        /// </summary>
        /// <param name="value"></param>
        void RemoveItem(int value);
        /// <summary>
        /// получить узел дерева по значению
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        TreeNode GetNodeByValue(int value);
        /// <summary>
        /// вывести дерево в консоль
        /// </summary>
        void PrintTree();
    }
}
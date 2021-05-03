namespace lesson_4.HomeWork_2
{
    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        /// <summary>
        /// Возвращает количество элементов в списке
        /// </summary>
        /// <returns></returns>
        int GetCount();

        /// <summary>
        /// Добавляет новый элемент списка
        /// </summary>
        /// <param name="value"></param>
        void AddNode(int value);

        /// <summary>
        /// Добавляет новый элемент списка после определённого элемента
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        void AddNodeAfter(Node node, int value);

        /// <summary>
        /// Удаляет элемент по порядковому номеру
        /// </summary>
        /// <param name="index"></param>
        void RemoveNode(int index);

        /// <summary>
        /// Удаляет указанный элемент
        /// </summary>
        /// <param name="node"></param>
        void RemoveNode(Node node);

        /// <summary>
        /// Ищет элемент по его значению
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        Node FindNode(int searchValue);
    }
}
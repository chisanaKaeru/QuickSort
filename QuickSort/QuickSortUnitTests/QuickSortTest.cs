using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;

namespace QuickSortUnitTests
{
    public class QuickSortUnitTests
    {
        [Fact]
        public void TestNotNullFile()
        {
            //Arrange
            string filePath = "DataArray.txt";
            
            //Act
            QuickSort.ReadDataFromFile(filePath);
            string lines = File.ReadAllText(filePath).ToString();

            //Assert
            Assert.NotNull(filePath);
            Assert.NotNull(lines);
        }

        [Fact]
        public void TestNotDeletingElementsArray() 
        {//negative

            //Arrange
            int[] array = new[] { 4, 7, 0, 1, 5, 8, 34, 35, 34, 35, 45, 34, 2, 65 };
            int k = 0;
            //Act
            QuickSort.QuickSortAlgorithm(array, 0, array.Length - 1);
            foreach (var item in array)
            {
                if (item != 0)
                {
                    k++;
                }
                else k--;
            }

            //Assert
            Assert.True(k > 0);
            Assert.True(array.Length == array.Length);
        }

        [Fact]
        public void TestCorrectSortingElement()
        {
            //Arrange
            int[] arrayOne = new[] {6, 5, 8, 1, 9, 10, 4, 35, 3, 11, 45};
            int[] arrayTwo = new[] {1, 3, 4, 5, 6, 8, 9, 10, 11, 35, 45};
            int k = 0;

            //Act
            QuickSort.QuickSortAlgorithm(arrayOne, 0, arrayOne.Length - 1);
            for (int i = 0; i < 10; i++)
            {
                if (arrayOne[i] == arrayTwo[i])
                {
                    k++;
                }
                else k--;
            }

            //Assert
            Assert.True(k == 10);
        }
    }
}
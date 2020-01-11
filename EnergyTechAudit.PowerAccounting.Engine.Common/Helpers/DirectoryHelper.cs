using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EnergyTechAudit.PowerAccounting.DeviceReader.Common.Helpers
{
    public static class DirectoryHelper
    {
        private static DirectoryInfo GetDirectoryPath(string directoryName)
        {
            var rootSolution = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (rootSolution != null)
            {
                var directories = rootSolution.GetDirectories();
                if (directories.Any(p => p.Name == directoryName))
                {
                    var directory = directories.FirstOrDefault(d => d.Name == directoryName);
                    if (directory != null)
                    {
                        return directory;
                    }
                }
                rootSolution = Directory.GetParent(rootSolution.FullName);
            }

            return null;
        }

        public static IEnumerable<FileInfo> RecursiveDownFind(DirectoryInfo root, Predicate<FileInfo> predicate)
        {
            var collector = new List<FileInfo>();

            Action<DirectoryInfo, Predicate<FileInfo>> innerRecursiveDownFind = null;

            innerRecursiveDownFind = (r, p) =>
            {
                collector.AddRange(r.GetFiles()
                                .Where(fileInfo => p(fileInfo)));

                r.GetDirectories()
                    .ToList()
                    .ForEach(subdirectory => innerRecursiveDownFind(subdirectory, p));
            };

            innerRecursiveDownFind(root, predicate);

            return collector;
        }

        /// <summary>
        /// Возвращает полный физический путь к файлу по его имени
        /// </summary>
        /// <param name="root">Корневая директория, с которой начинается поиск файла вглубь</param>
        /// <param name="fileName">Имя файла (например, pulsar.jpg)</param>
        /// <returns>Полный путь, в случае успеха; пустая строка - в случае отсутствия файла</returns>
        public static string GetFilePath(string fileName)
        {
            var path = GetDirectoryPath("DeviceConfig");
            var fileInfo = RecursiveDownFind(GetDirectoryPath("DeviceConfig"), f => f.Name.Contains(fileName)).FirstOrDefault();

            if (fileInfo != null)
            {
                return string.Format("{0}\\{1}", fileInfo.DirectoryName, fileName);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}

﻿using JWLMerge.BackupFileServices.Models.Database;

namespace JWLMerge.BackupFileServices
{
    using System;
    using System.Collections.Generic;
    using Events;
    using Models;

    /// <summary>
    /// The BackupFileService interface.
    /// </summary>
    public interface IBackupFileService
    {
        event EventHandler<ProgressEventArgs> ProgressEvent;
        
        /// <summary>
        /// Loads the specified backup file.
        /// </summary>
        /// <param name="backupFilePath">
        /// The backup file path.
        /// </param>
        /// <returns>
        /// The <see cref="BackupFile"/>.
        /// </returns>
        BackupFile Load(string backupFilePath);

        /// <summary>
        /// Merges the specified backup files.
        /// </summary>
        /// <param name="files">The files.</param>
        /// <returns>Merged file</returns>
        BackupFile Merge(IReadOnlyCollection<string> files);
            

        /// <summary>
        /// Merges the specified backup files.
        /// </summary>
        /// <param name="files">The files.</param>
        /// <returns>Merged file</returns>
        BackupFile Merge(IReadOnlyCollection<BackupFile> files);

        /// <summary>
        /// Creates a blank backup file.
        /// </summary>
        /// <returns>
        /// A <see cref="BackupFile"/>.
        /// </returns>
        BackupFile CreateBlank();

        /// <summary>
        /// Writes the specified backup to a "jwlibrary" file.
        /// </summary>
        /// <param name="backup">The backup data.</param>
        /// <param name="newDatabaseFilePath">The new database file path.</param>
        /// <param name="originalJwlibraryFilePathForSchema">The original jwlibrary file path on which to base the new schema.</param>
        void WriteNewDatabase(
            BackupFile backup, 
            string newDatabaseFilePath,
            string originalJwlibraryFilePathForSchema);

        /// <summary>
        /// Removes all the tags from the specified database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>Number of items removed</returns>
        int RemoveTags(Database database);

        /// <summary>
        /// Removes bookmarks from the specified database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>Number of items removed</returns>
        int RemoveBookmarks(Database database);

        /// <summary>
        /// Removes notes from the specified database.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>Number of items removed</returns>
        int RemoveNotes(Database database);

        /// <summary>
        /// Removes underlining (user marks) from the specified database
        /// </summary>
        /// <param name="database">The database.</param>
        /// <returns>Number of items removed</returns>
        int RemoveUnderlining(Database database);
    }
}

﻿using System;
using UnityEngine;
using System.Collections.Generic;
using HoloToolkit.Unity.SpatialMapping;

namespace UWBNetworkingPackage
{
    /// <summary>
    /// Database is a static class that stores the most recently sent Room Mesh (the Room Mesh is created by a HoloLens),
    /// and allows any classes in the UWBNetworkingPackage to access it
    /// </summary>
    // Note: For future improvment, you should add: a) Parameter check
    public class Database
    {
        #region Private Properties

        private static byte[] _meshes;  // Stores the current Room Mesh data as a serialized byte array

        #endregion

        #region Public Properties

        public static DateTime LastUpdate = DateTime.MinValue;  // Used for keeping the Room Map up-to-date

        #endregion

        /// <summary>
        /// Retrieves the Room Mesh as a deserialized list
        /// </summary>
        /// <returns>Deserialized Room Mesh</returns>
        public static IEnumerable<Mesh> GetMeshAsList()
        {
            return SimpleMeshSerializer.Deserialize(_meshes);
        }

        /// <summary>
        /// Retrieves the Room Mesh as a serialized byte array
        /// </summary>
        /// <returns>Serialized Room Mesh</returns>
        public static byte[] GetMeshAsBytes()
        {
            return _meshes;
        }

        /// <summary>
        /// Update the currently saved mesh to be the given deserialized Room Mesh
        /// This method will also update the LastUpdate time
        /// </summary>
        /// <param name="newMesh">Deserialized Room Mesh stored in a list</param>
        public static void UpdateMesh(IEnumerable<Mesh> newMesh)
        {
            _meshes = SimpleMeshSerializer.Serialize(newMesh);
            LastUpdate = DateTime.Now;
        }

        /// <summary>
        /// Update the currently saved mesh to be the given serialized Room Mesh
        /// This method will also update the LastUpdate time
        /// </summary>
        /// <param name="newMesh">Serialized Room Mesh stored in a byte array</param>
        public static void UpdateMesh(byte[] newMesh)
        {
            _meshes = newMesh;
            LastUpdate = DateTime.Now;
        }
    }
}
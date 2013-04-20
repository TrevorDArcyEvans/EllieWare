// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.32716
//    <NameSpace>RobotWare.Runtime.SpaceClaim.Commands</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>False</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>True</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net20</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>False</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>True</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace RobotWare.Runtime.SpaceClaim.Commands {
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;
    
    
    public partial class RuntimeConfig {
        
        private List<CommandConfig> commandConfigsField;
        
        private string ribbonTextField;
        
        private string tabTextField;
        
        private string panelTextField;
        
        private string panelIconField;
        
        private static System.Xml.Serialization.XmlSerializer serializer;
        
        public RuntimeConfig() {
            this.commandConfigsField = new List<CommandConfig>();
        }
        
        public List<CommandConfig> CommandConfigs {
            get {
                return this.commandConfigsField;
            }
            set {
                this.commandConfigsField = value;
            }
        }
        
        public string RibbonText {
            get {
                return this.ribbonTextField;
            }
            set {
                this.ribbonTextField = value;
            }
        }
        
        public string TabText {
            get {
                return this.tabTextField;
            }
            set {
                this.tabTextField = value;
            }
        }
        
        public string PanelText {
            get {
                return this.panelTextField;
            }
            set {
                this.panelTextField = value;
            }
        }
        
        public string PanelIcon {
            get {
                return this.panelIconField;
            }
            set {
                this.panelIconField = value;
            }
        }
        
        private static System.Xml.Serialization.XmlSerializer Serializer {
            get {
                if ((serializer == null)) {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(RuntimeConfig));
                }
                return serializer;
            }
        }
        
        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current RuntimeConfig object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize() {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try {
                memoryStream = new System.IO.MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally {
                if ((streamReader != null)) {
                    streamReader.Dispose();
                }
                if ((memoryStream != null)) {
                    memoryStream.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Deserializes workflow markup into an RuntimeConfig object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output RuntimeConfig object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out RuntimeConfig obj, out System.Exception exception) {
            exception = null;
            obj = default(RuntimeConfig);
            try {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex) {
                exception = ex;
                return false;
            }
        }
        
        public static bool Deserialize(string xml, out RuntimeConfig obj) {
            System.Exception exception = null;
            return Deserialize(xml, out obj, out exception);
        }
        
        public static RuntimeConfig Deserialize(string xml) {
            System.IO.StringReader stringReader = null;
            try {
                stringReader = new System.IO.StringReader(xml);
                return ((RuntimeConfig)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally {
                if ((stringReader != null)) {
                    stringReader.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Serializes current RuntimeConfig object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception) {
            exception = null;
            try {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e) {
                exception = e;
                return false;
            }
        }
        
        public virtual void SaveToFile(string fileName) {
            System.IO.StreamWriter streamWriter = null;
            try {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally {
                if ((streamWriter != null)) {
                    streamWriter.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Deserializes xml markup from file into an RuntimeConfig object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output RuntimeConfig object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out RuntimeConfig obj, out System.Exception exception) {
            exception = null;
            obj = default(RuntimeConfig);
            try {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex) {
                exception = ex;
                return false;
            }
        }
        
        public static bool LoadFromFile(string fileName, out RuntimeConfig obj) {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }
        
        public static RuntimeConfig LoadFromFile(string fileName) {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally {
                if ((file != null)) {
                    file.Dispose();
                }
                if ((sr != null)) {
                    sr.Dispose();
                }
            }
        }
        #endregion
    }
    
    public partial class CommandConfig {
        
        private string nameField;
        
        private string textField;
        
        private string imageField;
        
        private string hintField;
        
        private string specFileNameField;
        
        private static System.Xml.Serialization.XmlSerializer serializer;
        
        public CommandConfig() {
            this.hintField = "";
        }
        
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        public string Text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
        
        public string Image {
            get {
                return this.imageField;
            }
            set {
                this.imageField = value;
            }
        }
        
        [System.ComponentModel.DefaultValueAttribute("")]
        public string Hint {
            get {
                return this.hintField;
            }
            set {
                this.hintField = value;
            }
        }
        
        public string SpecFileName {
            get {
                return this.specFileNameField;
            }
            set {
                this.specFileNameField = value;
            }
        }
        
        private static System.Xml.Serialization.XmlSerializer Serializer {
            get {
                if ((serializer == null)) {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(CommandConfig));
                }
                return serializer;
            }
        }
        
        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current CommandConfig object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize() {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try {
                memoryStream = new System.IO.MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally {
                if ((streamReader != null)) {
                    streamReader.Dispose();
                }
                if ((memoryStream != null)) {
                    memoryStream.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Deserializes workflow markup into an CommandConfig object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output CommandConfig object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out CommandConfig obj, out System.Exception exception) {
            exception = null;
            obj = default(CommandConfig);
            try {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex) {
                exception = ex;
                return false;
            }
        }
        
        public static bool Deserialize(string xml, out CommandConfig obj) {
            System.Exception exception = null;
            return Deserialize(xml, out obj, out exception);
        }
        
        public static CommandConfig Deserialize(string xml) {
            System.IO.StringReader stringReader = null;
            try {
                stringReader = new System.IO.StringReader(xml);
                return ((CommandConfig)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally {
                if ((stringReader != null)) {
                    stringReader.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Serializes current CommandConfig object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception) {
            exception = null;
            try {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e) {
                exception = e;
                return false;
            }
        }
        
        public virtual void SaveToFile(string fileName) {
            System.IO.StreamWriter streamWriter = null;
            try {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally {
                if ((streamWriter != null)) {
                    streamWriter.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Deserializes xml markup from file into an CommandConfig object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output CommandConfig object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out CommandConfig obj, out System.Exception exception) {
            exception = null;
            obj = default(CommandConfig);
            try {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex) {
                exception = ex;
                return false;
            }
        }
        
        public static bool LoadFromFile(string fileName, out CommandConfig obj) {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }
        
        public static CommandConfig LoadFromFile(string fileName) {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally {
                if ((file != null)) {
                    file.Dispose();
                }
                if ((sr != null)) {
                    sr.Dispose();
                }
            }
        }
        #endregion
    }
}

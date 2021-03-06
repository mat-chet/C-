﻿using AuthApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Web;
using System.Xml;

namespace Saml
{
    class Class2
    {


        public static readonly string privateKey = @"MIIEpQIBAAKCAQEAyywLnfUHNG+lRRtddFIDZZLFkEZGOw1iN9UZ9k3EPSeiPFXLehBEvlX4hsuPs4UjnmnzbKAl/zUhl/lszLj4dDWDomsGdIMgDJDDBasBzeba4mrODN7iAMFiFjVBhAFuwEM017vxEXOuP1TxPBiF19fD0EvmHXrW1HW7+KF8524Deki00bGFdYQU1yDJE6estUw2s6noqnaK2zfRC0gh2ZocPbwQ51TlAIOLRf1ts43+/KsNSV7lye4JxLwWmEY8KDN3UogmBNr+nbDrvpbcYXNVbi6hIVo510CCwvcAVuwFOyfAsC/Gt3FJd6+7wdOGTYs1SMjucvb1umjFWlGVfQIDAQABAoIBADygNAc6ap/3ALYSaFyhbGoO1e0rSyGr6LcIW+rnYbtt7Ddc0o7l891oAfUXIRZMkEhhDUZIs43n6NJUl2ave1QR8+mvTgnOZu3Y9JjoYm1yibYucLXefEoFaqN92MLvOoEcjNQjPNgcUM6NJj7sgmPZ+pBZVZ1OXnSffSu/5GmaHjKqmpkpNTpsEekbVjM/9jvrmuW+fg/f1HaAro61bO1ZcZXwTP+a+XrHBvitfyw1iZQPLoBgIUNzLnrntZopQzt7HpzykO3RS4u64rXo4f+jKlfbyAH5mDB7FQW0p08PlhO+YKLBPaXU7lwnpzGWwvz+MEPSY8G1s1iKl6Z4AfECgYEA24ZyYF4Gv6ifYgAGRl0FF5cxMypSRr1NJ5wIbEnfXIXas9GVTg3+nKZXs/wvcY7XRLjI8wIAm4V9g7b+Ck9kzv0PT+rVP084qmZg5TOqcKdmu6ZGn7PyaMO9UIBq/bSW8dyT3a++MTtZU8QpsGdfqHzUSIefXim6mUhPKczye5cCgYEA7O4DtinJRMi9XrsSxSCkB3qNs/rzXGkULS2g9C8pQoqyfQJNXb0CYj+rUhUEZDe2SQliaNQIIebB3p+l2ZLHYlHb0GC4HOZNU63UUEIyiQr8f9/O35QHLf4NrOHqkEc8c05kSMeNsoF0AqxFcAexwFakbKZRar2ruONweXNMqgsCgYEAuZOcmQ6jkd4Qbp4qr8zvAxRTCTfbueVJlhR3omOIqQSW77BbEVMPTInqVkL4MH1aScQUTCoDLXXZt0E43KplQ/31tc+FWjG0a4iEnP3iNb2uQS+9QEC0yg++uJD24WaKvAeGEMACfkf3qbKIs5GP8jUkl/Peq5GHJxFTqriQvB0CgYEAwyNRqUIHRAC1f4VCc1tr3cEBXsAMmgrtlDwleZgyOlzznuQ7hj367aKU3vjycfw0xTjWdZJU1F8zQ8Fnnqg2UXMsQRa37Q19mLLtz+CFsLt8tXFG+Hv54daBuucjAwu47Rsem5bHzMK0ItNyKVAdBVYW/GmLWwe2nIOuikj9VnsCgYEAmvN7Zm8E4su48vLeFR7Unlgrp3+XHlepioWO7ktTtc4N7PVVYdwHopUUsUJXFNCWdUsQBkEX+LkKcFTw1O3ehoQULIUJu4N0nDZN2MOiOcyIm2cN8KnOs5qIZp6OswuOyfBsdNee1F+FyhueUWcNYFYDm3R4aAyt4zlT7VRpieU=";

        public static readonly string samlCertificate = @"-----BEGIN CERTIFICATE-----
MIIDIDCCAgygAwIBAgIQJdd6z34fIoBJQmMnQl4+NTAJBgUrDgMCHQUAMCMxITAfBgNVBAMeGABY
AE0ATABEAFMASQBHAF8AVABlAHMAdDAeFw0wNDEyMzEyMTAwMDBaFw0yNDEyMzEyMTAwMDBaMCMx
ITAfBgNVBAMeGABYAE0ATABEAFMASQBHAF8AVABlAHMAdDCCASIwDQYJKoZIhvcNAQEBBQADggEP
ADCCAQoCggEBAMssC531BzRvpUUbXXRSA2WSxZBGRjsNYjfVGfZNxD0nojxVy3oQRL5V+IbLj7OF
I55p82ygJf81IZf5bMy4+HQ1g6JrBnSDIAyQwwWrAc3m2uJqzgze4gDBYhY1QYQBbsBDNNe78RFz
rj9U8TwYhdfXw9BL5h161tR1u/ihfOduA3pItNGxhXWEFNcgyROnrLVMNrOp6Kp2its30QtIIdma
HD28EOdU5QCDi0X9bbON/vyrDUle5cnuCcS8FphGPCgzd1KIJgTa/p2w676W3GFzVW4uoSFaOddA
gsL3AFbsBTsnwLAvxrdxSXevu8HThk2LNUjI7nL29bpoxVpRlX0CAwEAAaNYMFYwVAYDVR0BBE0w
S4AQUrRdfGlM740goFyCqwKwd6ElMCMxITAfBgNVBAMeGABYAE0ATABEAFMASQBHAF8AVABlAHMA
dIIQJdd6z34fIoBJQmMnQl4+NTAJBgUrDgMCHQUAA4IBAQBct5fdq3PvNo1OhLWe7yvz+6LAdaM/
uaji7B6MrL65APtAJzGGLwRCCrILrdMfqCTf0XFXq9Vf3Fjm2meRsMPEyQ/VauRMUsWc72hV5ZY0
cHiG8PyGG3mv3omo/XR5h24H5VaklrFYBmwVouNhQvqTayad/LeK6wBiJp3MBm3JvtpGyveWoaRC
4XMKpGUKXu2yGm8/NVr6SpEwu3oyAcyMPhdobuU5r3cN2jPJ/h/zOwYsZzn9qTuJNnFenqIj90hS
oNVlZT4m67z8suA10VnnUI7g6jBLoXj+EVHF63kQaRLavbxROgzopOZu96h1/VYzf+a15Z7qgbKA
i5pXyDNc
-----END CERTIFICATE-----";



		public static XmlDocument SignXml(string XMLtext, string SubjectName, string privateKey)
        {
            if (null == XMLtext)
                throw new ArgumentNullException("XMLtext");
            if (null == SubjectName)
                throw new ArgumentNullException("SubjectName");

            // Load the certificate from the certificate store.
            X509Certificate2 cert = new X509Certificate2(StringToByteArray(SubjectName));

            // Create a new XML document.
            XmlDocument doc = new XmlDocument();

            // Format the document to ignore white spaces.
            doc.PreserveWhitespace = false;

            // Load the passed XML file using it's name.
            doc.LoadXml(XMLtext);

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(doc);

            RSA rsa = new RSACng();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);
            // Add the key to the SignedXml document. 
            signedXml.SigningKey = rsa;

            // Create a reference to be signed.
            Reference reference = new Reference();
            reference.Uri = "";

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            // Create a new KeyInfo object.
            KeyInfo keyInfo = new KeyInfo();

            // Load the certificate into a KeyInfoX509Data object
            // and add it to the KeyInfo object.
            keyInfo.AddClause(new KeyInfoX509Data(cert));

            // Add the KeyInfo object to the SignedXml object.
            signedXml.KeyInfo = keyInfo;

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

            if (doc.FirstChild is XmlDeclaration)
            {
                doc.RemoveChild(doc.FirstChild);
            }

            // Save the signed XML document to a file specified
            // using the passed string.
            return doc;
        }

        public static byte[] StringToByteArray(string st)
        {
            byte[] bytes = new byte[st.Length];
            for (int i = 0; i < st.Length; i++)
            {
                bytes[i] = (byte)st[i];
            }
            return bytes;
        }
    }
}

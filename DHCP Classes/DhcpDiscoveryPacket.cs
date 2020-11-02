﻿using System.Linq;

class DhcpDiscoveryPacket
{
    //-- MessageType, HardwareType, Hardware-Address-Length
    public byte[] firstPart { get; set; } = new byte[3] { 0x01, 0x01, 0x06 };

    //--hops : Anzahl der DHCP-Relay-Agents auf dem Datenpfad
    public byte[] hops { get; set; } = new byte[1]{ 0x00 };

    //--transactionID : ID der Verbindung zwischen Client und Server
    public byte[] transactionID { get; set; } = new byte[4] { 0x00, 0x00, 0x00, 0x00 };

    //--secs : Zeit in Sekunden seit dem Start des Clients
    public byte[] secs { get; set; } = new byte[2] { 0x0c, 0x00 };

    //--BootpFlags : Z. Zt. wird nur das erste Bit verwendet (zeigt an, ob der Client noch eine gültige IP-Adresse hat), die restlichen Bits sind für spätere Protokollerweiterungen reserviert
    public byte[] bootpFlags { get; set; } = new byte[2] { 0x00, 0x00 };

    //--clientIP : Client-IP-Adresse
    public byte[] clientIP { get; set; } = new byte[4] { 0x00, 0x00, 0x00, 0x00 };

    //--yourIP : eigene IP-Adresse
    public byte[] yourIP { get; set; } = new byte[4] { 0x00, 0x00, 0x00, 0x00 };

    //--nextServerIP : Server-IP-Adresse
    public byte[] nextServerIP { get; set; } = new byte[4] { 0x00, 0x00, 0x00, 0x00 };

    //--relayAgentIP : Relay-Agent-IP-Adresse
    public byte[] relayAgentIP { get; set; } = new byte[4] { 0x00, 0x00, 0x00, 0x00 };

    //--clientMac : Client-MAC-Adresse
    public byte[] clientMac { get; set; } = new byte[6] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

    //--clientMacPadding : 
    public byte[] clientMacPadding { get; set; } = new byte[10] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

    //--serverHostname :  Name des DHCP-Servers, falls ein bestimmter gefordert wird (enthält C-String), Angabe optional
    public byte[] serverHostname { get; set; } = new byte[64] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

    //--bootFilename :  Name einer Datei (z. B. System-Kernel), die vom Server per TFTP an den Client gesendet werden soll (enthält C-String), Angabe optional
    public byte[] bootFilename { get; set; } = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

    //--magicCookie : 
    public byte[] magicCookie { get; set; } = new byte[4] { 0x63, 0x82, 0x53, 0x63 };

    //--dhcpMessageType (Discover)
    public byte[] dhcpMessageType { get; set; } = new byte[3] { 0x35, 0x01, 0x01 };

    //--clientIdentifier
    private byte[] clientIdentifierPre { get; set; } = new byte[3] { 0x3d, 0x07, 0x01 };
    public byte[] clientIdentifier { get; set; } = new byte[6] {0x00, 0x1c, 0x21, 0x3a, 0x60, 0x62 };

    //--hostName
    public byte[] hostName { get; set; } = new byte[8] { 0x0c, 0x06, 0x70, 0x63, 0x5f, 0x6d, 0x61, 0x78  };

    //--vendorClassIndentifier
    public byte[] vendorClassIndentifier { get; set; } = new byte[10] { 0x3c, 0x08, 0x4d, 0x53, 0x46, 0x54, 0x20, 0x35, 0x2e, 0x30 };

    //--parameterRequestList
    public byte[] parameterRequestList { get; set; } = new byte[16] { 0x37, 0x0e, 0x01, 0x03, 0x06, 0x0f, 0x1f, 0x21, 0x2b, 0x2c, 0x2e, 0x2f, 0x77, 0x79, 0xf9, 0xfc };

    //--end
    public byte[] end { get; set; } = new byte[1] { 0xff };

    //--Padding
    public byte[] padding { get; set; } = new byte[13] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,  0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

    public byte[] buildPacket()
    {
        return firstPart.Concat(hops).Concat(transactionID).Concat(secs).Concat(bootpFlags).Concat(clientIP).Concat(yourIP).Concat(nextServerIP).Concat(relayAgentIP).Concat(clientMac).Concat(clientMacPadding).Concat(serverHostname).Concat(bootFilename).Concat(magicCookie).Concat(dhcpMessageType).Concat(clientIdentifierPre).Concat(clientIdentifier).Concat(hostName).Concat(vendorClassIndentifier).Concat(parameterRequestList).Concat(end).Concat(padding).ToArray();
    }
}

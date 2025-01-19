<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:output method="html" indent="yes" />

    <xsl:template match="/">
        <html>
            <head>
                <title>Character List</title>
            </head>
            <body>
                <h1>Character List</h1>
                <table border="1">
                    <tr>
                        <th>Name</th>
                        <th>Class</th>
                        <th>Level</th>
                    </tr>
                    <xsl:for-each select="Characters/Character">
                        <tr>
                            <td><xsl:value-of select="Name" /></td>
                            <td><xsl:value-of select="Class" /></td>
                            <td><xsl:value-of select="Level" /></td>
                        </tr>
                    </xsl:for-each>
                </table>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>

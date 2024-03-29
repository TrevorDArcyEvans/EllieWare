<?xml version="1.0"?>
<!--
    This is the XSL HTML stylesheet for the Spring reference Documentation.
-->
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns="http://www.w3.org/TR/xhtml1/transitional"
                xmlns:fo="http://www.w3.org/1999/XSL/Format"
                exclude-result-prefixes="#default"
                version="1.0">

  <xsl:import href="../html/chunk.xsl" />

  <!--###################################################
                         General
    ################################################### -->
  <xsl:param name="base.dir">html/</xsl:param>
  <xsl:param name="manifest.in.base.dir">html/</xsl:param>

  <!--###################################################
                     HTML Settings
    ################################################### -->
  <xsl:param name="chunk.section.depth">'5'</xsl:param>
  <xsl:param name="use.id.as.filename">'1'</xsl:param>
  <xsl:param name="html.stylesheet">styles/html.css</xsl:param>
  <!-- These extensions are required for table printing and other stuff -->
  <xsl:param name="use.extensions">1</xsl:param>
  <xsl:param name="tablecolumns.extension">0</xsl:param>
  <xsl:param name="callout.extensions">1</xsl:param>
  <xsl:param name="graphicsize.extension">0</xsl:param>

  <!--###################################################
                      Table Of Contents
    ################################################### -->
  <!-- Generate the TOCs for named components only -->
  <xsl:param name="generate.toc">
    book   toc
  </xsl:param>
  <!-- Show only Sections up to level 3 in the TOCs -->
  <xsl:param name="toc.section.depth">3</xsl:param>

  <!--###################################################
                         Labels
    ################################################### -->
  <!-- Label Chapters and Sections (numbering) -->
  <xsl:param name="chapter.autolabel">1</xsl:param>
  <xsl:param name="section.autolabel" select="1" />
  <xsl:param name="section.label.includes.component.label" select="1" />

  <!--###################################################
                         Callouts
    ################################################### -->
  <!-- Use images for callouts instead of (1) (2) (3) -->
  <xsl:param name="callout.graphics">1</xsl:param>
  <xsl:param name="callout.graphics.path">images/callouts/</xsl:param>
  <!-- Place callout marks at this column in annotated areas -->
  <xsl:param name="callout.defaultcolumn">90</xsl:param>

  <!--###################################################
                       Admonitions
    ################################################### -->
  <!-- Use nice graphics for admonitions -->
  <xsl:param name="admon.graphics">1</xsl:param>
  <xsl:param name="admon.graphics.path">images/admons/</xsl:param>

  <!--###################################################
                          Misc
    ################################################### -->
  <!-- Placement of titles -->
  <xsl:param name="formal.title.placement">
    figure after
    example before
    equation before
    table before
    procedure before
  </xsl:param>
  <xsl:template match="author" mode="titlepage.mode">
    <xsl:if test="name(preceding-sibling::*[1]) = 'author'">
      <xsl:text>, </xsl:text>
    </xsl:if>
    <span class="{name(.)}">
      <xsl:call-template name="person.name" />
      <xsl:apply-templates mode="titlepage.mode" select="./contrib" />
      <xsl:apply-templates mode="titlepage.mode" select="./affiliation" />
    </span>
  </xsl:template>
  <xsl:template match="authorgroup" mode="titlepage.mode">
    <div class="{name(.)}">
      <p class="title">Authors</p>
      <xsl:apply-templates mode="titlepage.mode" />
    </div>
  </xsl:template>

  <!--###################################################
                     Headers and Footers
    ################################################### -->
  <!-- let's have a Spring and I21 banner across the top of each page -->
  <xsl:template name="user.header.navigation">
<!--
    <div style="background-color:white;border:none;height:73px;border:1px solid black;">
      <a style="border:none;" href="http://www.springframework.net/" title="The Spring Framework">
        <img style="border:none;" src="images/xdev-spring_logo.jpg" />
      </a>
      <a style="border:none;" href="http://www.springsource.com/" title="SpringSource">
        <img style="border:none;position:absolute;padding-top:5px;right:42px;" src="images/S2-banner-rhs.png" />
      </a>
    </div>
-->
		<div style="border: 1px solid black; background-color: white; height: 73px;" xmlns="http://www.w3.org/TR/xhtml1/transitional">
			<a title="Common Infrastructure Libraries for .NET" href="http://netcommon.sf.net/" style="border: medium none ;">
				<img src="images/netcommon-logo.gif" style="border: medium none ;"/>
			</a>
			<a title="Common Infrastructure Libraries for .NET" href="http://netcommon.sf.net/" style="border: medium none ;">
				<img src="images/bubble-big.jpg" style="border: medium none ; position: absolute; padding-top: 5px; right: 32px;"/>
			</a>
		</div>
  </xsl:template>
  <!-- no other header navigation (prev, next, etc.) -->
  <xsl:template name="header.navigation" />
  <xsl:param name="navig.showtitles">1</xsl:param>
  <!-- let's have a 'Sponsored by SpringSource' strapline (or somesuch) across the bottom of each page -->
  <xsl:template name="footer.navigation">
    <xsl:param name="prev" select="/foo" />
    <xsl:param name="next" select="/foo" />
    <xsl:param name="nav.context" />
    <xsl:variable name="home" select="/*[1]" />
    <xsl:variable name="up" select="parent::*" />
    <xsl:variable name="row1" select="count($prev) &gt; 0
                                        or count($up) &gt; 0
                                        or count($next) &gt; 0" />
    <xsl:variable name="row2" select="($prev and $navig.showtitles != 0)
                                        or (generate-id($home) != generate-id(.)
                                            or $nav.context = 'toc')
                                        or ($chunk.tocs.and.lots != 0
                                            and $nav.context != 'toc')
                                        or ($next and $navig.showtitles != 0)" />
    <xsl:if test="$suppress.navigation = '0' and $suppress.footer.navigation = '0'">
      <div class="navfooter">
        <xsl:if test="$footer.rule != 0">
          <hr />
        </xsl:if>
        <xsl:if test="$row1 or $row2">
          <table width="100%" summary="Navigation footer">
            <xsl:if test="$row1">
              <tr>
                <td width="40%" align="left">
                  <xsl:if test="count($prev)>0">
                    <a accesskey="p">
                      <xsl:attribute name="href">
                        <xsl:call-template name="href.target">
                          <xsl:with-param name="object" select="$prev" />
                        </xsl:call-template>
                      </xsl:attribute>
                      <xsl:call-template name="navig.content">
                        <xsl:with-param name="direction" select="'prev'" />
                      </xsl:call-template>
                    </a>
                  </xsl:if>
                  <xsl:text>&#160;</xsl:text>
                </td>

                <td width="20%" align="center">
                  <xsl:choose>
                    <xsl:when test="$home != . or $nav.context = 'toc'">
                      <a accesskey="h">
                        <xsl:attribute name="href">
                          <xsl:call-template name="href.target">
                            <xsl:with-param name="object" select="$home" />
                          </xsl:call-template>
                        </xsl:attribute>
                        <xsl:call-template name="navig.content">
                          <xsl:with-param name="direction" select="'home'" />
                        </xsl:call-template>
                      </a>
                      <xsl:if test="$chunk.tocs.and.lots != 0 and $nav.context != 'toc'">
                        <xsl:text>&#160;|&#160;</xsl:text>
                      </xsl:if>
                    </xsl:when>
                    <xsl:otherwise>&#160;</xsl:otherwise>
                  </xsl:choose>
                  <xsl:if test="$chunk.tocs.and.lots != 0 and $nav.context != 'toc'">
                    <a accesskey="t">
                      <xsl:attribute name="href">
                        <xsl:apply-templates select="/*[1]" mode="recursive-chunk-filename">
                          <xsl:with-param name="recursive" select="true()" />
                        </xsl:apply-templates>
                        <xsl:text>-toc</xsl:text>
                        <xsl:value-of select="$html.ext" />
                      </xsl:attribute>
                      <xsl:call-template name="gentext">
                        <xsl:with-param name="key" select="'nav-toc'" />
                      </xsl:call-template>
                    </a>
                  </xsl:if>
                </td>
                <td width="40%" align="right">
                  <xsl:text>&#160;</xsl:text>
                  <xsl:if test="count($next)>0">
                    <a accesskey="n">
                      <xsl:attribute name="href">
                        <xsl:call-template name="href.target">
                          <xsl:with-param name="object" select="$next" />
                        </xsl:call-template>
                      </xsl:attribute>
                      <xsl:call-template name="navig.content">
                        <xsl:with-param name="direction" select="'next'" />
                      </xsl:call-template>
                    </a>
                  </xsl:if>
                </td>
              </tr>
            </xsl:if>
            <xsl:if test="$row2">
              <tr>
                <td width="40%" align="left" valign="top">
                  <xsl:if test="$navig.showtitles != 0">
                    <xsl:apply-templates select="$prev" mode="object.title.markup" />
                  </xsl:if>
                  <xsl:text>&#160;</xsl:text>
                </td>
                <td width="20%" align="center">
                  <span style="color:white;font-size:90%;">
                    <a href="http://www.springsoure.com/" title="SpringSource">Sponsored by SpringSource</a>
                  </span>
                </td>
                <td width="40%" align="right" valign="top">
                  <xsl:text>&#160;</xsl:text>
                  <xsl:if test="$navig.showtitles != 0">
                    <xsl:apply-templates select="$next" mode="object.title.markup" />
                  </xsl:if>
                </td>
              </tr>
            </xsl:if>
          </table>
        </xsl:if>
      </div>
    </xsl:if>
  </xsl:template>

  <!--###################################################
                        Highlighting
    ################################################### -->
  <xsl:param name="highlight.source">1</xsl:param>

  <xsl:template match="classname">
    <span style="color: #2B91AF">
      <xsl:apply-templates/>
    </span>
  </xsl:template>
  <xsl:template match="exceptionname">
    <span style="color: #2B91AF">
      <xsl:apply-templates/>
    </span>
  </xsl:template>
  <xsl:template match="interfacename">
    <span style="color: #2B91AF">
      <xsl:apply-templates/>
    </span>
  </xsl:template>

</xsl:stylesheet>

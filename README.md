# MsBuildHtmlLogger
# MsBuild Html Logger

# Usage

Le livrable est un assemblage .Net donn� en argument '/logger' de la commande MsBuild: 

	msbuild /logger:HtmlLogger.dll 

Par d�fault, il produit dans le r�pertoire courrant le fichier html nomm� par exemple 'build.log.070919_152944.html'.

La variable d'environnement 'MSLOGGER_STREAMING_CMD', si positionn�e, lui indique de passer le log Html de msbuild 
en entr�e standart d'une execution de cette commande, sp�cifi�e par la valeur de la-dite variable:

	MSLOGGER_STREAMING_CMD=cat msbuild /logger:HtmlLogger.dll /nologo /m

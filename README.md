# MsBuildHtmlLogger
# MsBuild Html Logger

# Usage

Le livrable est un assemblage .Net donné en argument '/logger' de la commande MsBuild: 

	msbuild /logger:HtmlLogger.dll 

Par défault, il produit dans le répertoire courrant le fichier html nommé par exemple 'build.log.070919_152944.html'.

La variable d'environnement 'MSLOGGER_STREAMING_CMD', si positionnée, lui indique de passer le log Html de msbuild 
en entrée standart d'une execution de cette commande, spécifiée par la valeur de la-dite variable:

	MSLOGGER_STREAMING_CMD=cat msbuild /logger:HtmlLogger.dll /nologo /m

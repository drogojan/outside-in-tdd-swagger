#!/bin/bash

CLI_JAR="../cli/swagger-codegen-cli-2.4.4.jar"
TEMPLATES_PATH="../templates"
SPEC_FOLDER="../openapi-2.0"
OUTPUT_FOLDER="../generated"

CURRENT_YEAR=`date +'%Y'`

java -jar ${CLI_JAR} generate \
    -l csharp \
    -i ${SPEC_FOLDER}/sfmc-openapi-v2.json \
    -t ${TEMPLATES_PATH} \
    -o ${OUTPUT_FOLDER} \
    -c ${SPEC_FOLDER}/swagger-codegen-config-csharp.json \
    -DmodelTests=false \
    --additional-properties packageTitle="Salesforce Marketing Cloud C# SDK" \
    --additional-properties packageCompany="Salesforce" \
    --additional-properties packageProductName="Salesforce Marketing Cloud C# SDK" \
    --additional-properties packageDescription="The Salesforce Marketing Cloud C# SDK" \
    --additional-properties packageAuthors="Salesforce" \
    --additional-properties packageCopyright="Copyright © Salesforce ${CURRENT_YEAR}" \

exit $?
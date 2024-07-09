#
# This example sets up a tada solution and adds the following services
# organisation, user, product, customer and order.
# 
# NOTE The entities, domain requests and responses don't have any properties
#
# To use copy this script into an empty folder and execute.

tada new Example1
tada add service Organisation --type full
tada add service User --type full
tada add service Product --type full
tada add service Customer --type full
tada add service Order --type full

# add a db migration called Initial
tada db add Initial

# start sql server docker container
docker compose up -d

# Apply migration to database
tada db update

# start the app
tada app serve

# Next Steps
# Add properties to the database properties
# Add properties to the domain service models
# Update the mappings between the models and entities in the DbMappings classes.
# Use a imagem base do Nginx
FROM nginx:alpine

# Copie os arquivos construídos para o diretório padrão do Nginx
COPY ./dist/Gestao-de-investimentos-app /usr/share/nginx/html

# Exponha a porta 80 para o tráfego HTTP
EXPOSE 80

# Comando padrão para rodar o Nginx
CMD ["nginx", "-g", "daemon off;"]
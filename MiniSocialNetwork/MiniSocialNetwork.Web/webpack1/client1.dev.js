const path = require('path');
const webpack = require('webpack');
//const ExtractTextPlugin = require('extract-text-webpack-plugin');

module.exports = {
    context: path.join(__dirname, '../client'),
    devtool: 'inline-source-map',
    entry: [
        'react-hot-loader/patch',
        'webpack-dev-server/client?http://localhost:8080',
        'webpack/hot/only-dev-server',
        '../ClientApp/main.jsx',
        '../content/style/main.scss',
    ],
    output: {
        path: __dirname + '/../public/',
        filename: './js/bundle.js'
    },
    devServer: {
        hot: true,
        publicPath: '/',
        historyApiFallback: true
    },
    module: {
        rules: [{
                test: /\.(js|jsx?)$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['react', 'env', 'stage-0'],
                    },
                },
            },
            {
                test: /\.(scss|sass)$/,
                use: ['style-loader', 'css-loader', 'sass-loader']
            },
            {
                test: /\.(png|jpg|gif|svg)$/,
                use: [{
                    loader: 'file-loader',
                    options: {}
                }]
            },
            {
                test: /\.(otf|eot|ttf|woff|woff2)$/,
                use: [{
                    loader: 'file-loader',
                    options: {}
                }]
            }
        ],
    },
    resolve: {
        extensions: ['.js', '.jsx']
    },
    plugins: [
        new webpack.HotModuleReplacementPlugin(),
        new webpack.NamedModulesPlugin()
    ]
};
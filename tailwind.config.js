export default {
    content: [
        "./Components/**/*.{razor,html}",
        "./Pages/**/*.{razor,html}",
        "./Shared/**/*.{razor,html}",
        "./**/*.cshtml",
        "./wwwroot/index.html"
    ],
    theme: {
        extend: {},
    },
    plugins: [],
}
module.exports = {
    content: ["./**/*.razor", "./**/*.html"],
    theme: {
        extend: {
            colors: {
                retro: "#0e0e0e",
                panel: "#161616",
                line: "#d4d4d4",
                accent: "#cfcfcf"
            },
            fontFamily: {
                pixel: ["'Press Start 2P'", "monospace"],
                retro: ["'Share Tech Mono'", "monospace"]
            },
            boxShadow: {
                retro: "0 0 0 1px #d4d4d4, inset 0 0 0 1px #d4d4d4"
            }
        }
    },
    plugins: []
}
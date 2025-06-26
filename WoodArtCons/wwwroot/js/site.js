window.getLanguage = () => {
    return localStorage.getItem("language") || "ro-RO"
}

window.setLanguage = (language) => {
    localStorage.setItem("language", language)
}

window.downloadFile = (url, fileName) => {
    const link = document.createElement("a")
    link.href = url
    link.download = fileName
    document.body.appendChild(link)
    link.click()
    document.body.removeChild(link)
}
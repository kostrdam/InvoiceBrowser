const styles = (sidebarWidth) => ({
    root: {
        display: "flex"
    },

    appbar: {
        width: `calc(100% - ${sidebarWidth}px)`,
        marginLeft: sidebarWidth
    }
});

export default styles;